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

    protected FileManager fileManager;
    protected CommandExceptionManager commandExceptionManager;

    public Copy(CommandExceptionManager commandExceptionManager, FileManager fileManager) {
        this.commandExceptionManager = commandExceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isCopyValid(command)) {
            return;
        }

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
        if (!fileManager.isFileValid(sourceFile)) {
            return;
        }

        if (sourceFile.isDirectory()) {
            processDirectoryCopy(sourceFile, targetFile);
            return;
        }

        processFileCopy(sourceFile, targetFile);

        ArrayList<File> fileList = new ArrayList<>();
        fileList.add(sourceFile);
        printSuccess(fileList);
    }

    private void processDirectoryCopy(File sourceDirectory, File targetFile) {
        File[] files = sourceDirectory.listFiles();
        List<File> sourceFileList = new ArrayList<>();

        for(File file : files) {
            if (file.isDirectory()) {
                continue;
            }
            sourceFileList.add(file);
        }

        for(File sourceFile : sourceFileList) {
            processFileCopy(sourceFile, targetFile);
        }

        printSuccess(sourceFileList);
    }

    private void processFileCopy(File sourceFile, File targetFile) {
        // 새로운 파일로 복사를 할 때
        if (!targetFile.exists()) {
            copy(sourceFile, targetFile);
            return;
        }

        // 기존의 폴더안에 복사를 할 때
        if ((targetFile.exists() && targetFile.isDirectory())) {
            copy(sourceFile, new File(targetFile + "\\" + sourceFile.getName()));
            return;
        }

        // 기존 파일에 덮어씌울 때
        if (fileManager.whetherOverWrite(sourceFile)) {
            copy(sourceFile, targetFile);
        }
    }

    private void copy(File source, File target) {
        try {
            Files.copy(source.toPath(), target.toPath(), StandardCopyOption.REPLACE_EXISTING);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private void printSuccess(List<File> files) {
        for(File file : files) {
            System.out.println(file.getParentFile().getName() + "\\" + file.getName());
        }
        System.out.println("         " + files.size() + Constants.VALID_COPY);
    }
}
