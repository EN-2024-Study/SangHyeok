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

        File targetFile = fileManager.getFile(currentFile.toString(), inputPath);

        // 두개의 경로가 존재할 때
        if (fileManager.isTwoPaths(inputPath)) {
            String[] paths = fileManager.getTwoPaths(inputPath);
            targetFile = fileManager.getFile(currentFile.toString(), paths[0]);
            File replaceFile = fileManager.getFile(currentFile.toString(), paths[1]);

            processCopy(targetFile, replaceFile);
            return;
        }

        processCopy(targetFile, currentFile);
    }

    private void processCopy(File targetFile, File replaceFile) {
        if (!targetFile.exists()) {
            System.out.println(Constants.WRONG_DIRECTOR);
            return;
        }

        if (replaceFile.exists()) {

            return;
        }

        try {
            Files.copy(targetFile.toPath(), replaceFile.toPath(), StandardCopyOption.REPLACE_EXISTING);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
