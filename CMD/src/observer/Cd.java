package observer;

import controller.CommandValidCheck;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;
import controller.FileManager;

import java.io.File;

public class Cd implements IObserver {

    private FileManager fileManager;
    private CommandValidCheck commandValidCheck;

    public Cd(CommandValidCheck commandValidCheck, FileManager fileManager) {
        this.commandValidCheck = commandValidCheck;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandValidCheck.isCdValid(command)) {
            return;
        }

        processCommand(cmd, command);
    }

    private void processCommand(Cmd cmd, String command) {
        String inputPath = fileManager.removeCommand(command.replace("/", "\\"), Constants.COMMANDS[0].length());
        inputPath = inputPath.replace("\"", "");

        if (isProcessException(cmd.getCurrentPath(), inputPath))
            return;

        File currentFile = fileManager.getFile(cmd.getCurrentPath(), inputPath);
        if (inputPath.equals("\\")) {    // 최상위 경로일 때
            currentFile = fileManager.getAbsoluteFile(Constants.ABSOLUTE_FRONT_STRING);
        }

        if (!currentFile.isDirectory()) {  // 유효한 경로가 아닐 때
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmd.setCurrentPath(currentFile + ">");
    }

    private boolean isProcessException(String currentPath, String path) {
        if (path.isEmpty()) {
            System.out.println(currentPath);
            return true;
        }

        if (path.length() == 1) {
            switch (path.charAt(0)) {
                case ' ', '=', '&' -> {
                    System.out.println(currentPath);
                    return true;
                }
                case '.' -> {
                    System.out.println();
                    return true;
                }
                case '\\' -> {
                    return false;
                }
            }
        }
        return false;
    }
}
