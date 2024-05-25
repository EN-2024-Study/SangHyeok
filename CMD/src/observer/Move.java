package observer;

import controller.*;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

public class Move extends OverWriteManager implements IObserver {

    private CommandExceptionManager commandExceptionManager;
    private FileManager fileManager;

    public Move(CommandExceptionManager commandExceptionManager, FileManager fileManager) {
        super(fileManager);
        this.commandExceptionManager = commandExceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isMoveValid(command)) {
            return;
        }

        super.initAnswer();
        processCommand(cmd.getCurrentPath(), command);
    }

    private void processCommand(String currentPath, String command) {
        File currentFile = new File(currentPath);
        String inputPath = fileManager.removeCommand(command, Constants.COMMANDS[6].length());

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

            processMove(sourceFile, targetFile);
            return;
        }

        // 한개의 경로만 존재할 때
        File sourceFile = fileManager.getFile(currentFile.toString(), inputPath);
        processMove(sourceFile, currentFile);
    }

    private void processMove(File sourceFile, File targetFile) {
        if (!sourceFile.exists()) {
            System.out.println(Constants.WRONG_FILE);
            return;
        }

        if (targetFile.isDirectory()) {
            targetFile = new File(targetFile + "\\" + sourceFile.getName());
        }

        //================= sourceFile.exists() =================//

        if (!targetFile.exists()) {
            printSuccess(sourceFile.isFile(), 1);
            move(sourceFile, targetFile);
            return;
        }

        //================= sourceFile.exists() && targetFile.exists() =================//

        if (super.isProcessOverWrite(targetFile.toString())) {      // 복사 하려는 폴더에 이미 존재 할 때
            if (targetFile.isFile()) {

                return;
            }
            System.out.println(Constants.WRONG_ACCESS);
        }
        else
            printSuccess(sourceFile.isFile(), 0);
    }

    private void move(File source, File target) {
        try {
            Files.move(source.toPath(), target.toPath(), StandardCopyOption.REPLACE_EXISTING);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private void printSuccess(boolean isFile, int count) {
        if (isFile) {
            System.out.println("         " + count + Constants.VALID_FILE_MOVE);
            return;
        }
        System.out.println("         " + count + Constants.VALID_DIRECTORY_MOVE);
    }
}
