package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import controller.FileManager;
import utility.Constants;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.List;

public class Copy implements IObserver {

    private FileManager fileManager;
    private CommandExceptionManager commandExceptionManager;
    private Character answer;

    public Copy(CommandExceptionManager commandExceptionManager, FileManager fileManager) {
        this.commandExceptionManager = commandExceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isCopyValid(command)) {
            return;
        }

        this.answer = 'n';
        processCommand(cmd, command);
    }

    private void processCommand(Cmd cmd, String command) {
        File currentFile = new File(cmd.getCurrentPath());
        String inputPath = fileManager.removeCommand(command, Constants.COMMANDS[2].length());

        // 명령어만 존재할 때
        if (command.length() < 5 || inputPath.isEmpty()) {
            System.out.println(Constants.WRONG_COMMAND2);
            return;
        }

        // 두개의 경로가 존재할 때
        if (fileManager.isTwoPaths(inputPath)) {
            String[] paths = fileManager.getTwoPaths(inputPath);
            File sourceFile = fileManager.getFile(currentFile.toString(), paths[0]);
            File targetFile = fileManager.getFile(currentFile.toString(), paths[1]);

            processCopy(sourceFile, targetFile);
            return;
        }

        // 한개의 경로만 존재할 때
        File sourceFile = fileManager.getFile(currentFile.toString(), inputPath);
        processCopy(sourceFile, currentFile);
    }

    private void processCopy(File sourceFile, File targetFile) {
        if (!sourceFile.exists()) {
            System.out.println(Constants.WRONG_FILE);
            return;
        }

        if (sourceFile.isDirectory()) {
            processDirectoryCopy(sourceFile, targetFile);
            return;
        }

        if (isProcessFileCopy(sourceFile, targetFile))
            System.out.println("         " + 1 + Constants.VALID_COPY);
        else
            System.out.println("         " + 0 + Constants.VALID_COPY);
    }

    private void processDirectoryCopy(File sourceDirectory, File targetFile) {
        File[] files = sourceDirectory.listFiles();
        List<File> sourceFileList = new ArrayList<>();

        for(File file : files) {
            if (file.isDirectory()) {
                continue;
            }

            System.out.println(file.getParentFile().getName() + "\\" + file.getName());
            if (isProcessFileCopy(file, targetFile)) {
                sourceFileList.add(file);
            }
        }

        System.out.println("         " + sourceFileList.size() + Constants.VALID_COPY);
    }

    private boolean isProcessFileCopy(File sourceFile, File targetFile) {
        if (!targetFile.exists()) {
            copy(sourceFile, targetFile);
            return false;
        }

        // 파일이 존재하면서 폴더가 아닌 파일일 때
        if (!targetFile.isDirectory()) {
            return isProcessOverWrite(sourceFile, new File(targetFile + "\\" + sourceFile.getName()));
        }

        // 같은 경로에 복사를 할 때
        if (targetFile.getName().equals(sourceFile.getParentFile().getName())) {
            System.out.println(Constants.WRONG_COPY);
            return false;
        }

        targetFile = new File(targetFile + "\\" + sourceFile.getName());

        // 복사 하려는 폴더에 이미 존재 할 때
        if (targetFile.exists()) {
            return isProcessOverWrite(sourceFile, targetFile);
        }

        copy(sourceFile, targetFile);
        return true;
    }

    private boolean isProcessOverWrite(File source, File target) {
        // 기존 파일에 덮어씌울 때
        if (answer != 'a') {
            answer = fileManager.whetherOverWrite(target);
        }

        switch(answer) {
            case 'y', 'a' -> {
                copy(source, target);
                return true;
            }
        }
        return false;
    }

    private void copy(File source, File target) {
        try {
            Files.copy(source.toPath(), target.toPath(), StandardCopyOption.REPLACE_EXISTING);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}