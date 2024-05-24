package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;
import controller.FileManager;

import java.io.File;

public class Cd implements IObserver {

    private FileManager fileManager;
    private ExceptionManager exceptionManager;

    public Cd(ExceptionManager exceptionManager, FileManager fileManager) {
        this.exceptionManager = exceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!exceptionManager.isCdValid(command)) {
            return;
        }

        processCommand(cmd, command);
    }

    private void processCommand(Cmd cmd, String command) {
        String path = fileManager.getOnePath(command.replace("/", "\\"), 2);

        if (isProcessException(cmd.getCurrentPath(), path))
            return;

        File currentDirectory = getFile(cmd.getCurrentPath(), path);

        if (!fileManager.isFileValid(currentDirectory)) {  // 유효한 경로가 아닐 때
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmd.setCurrentPath(currentDirectory + ">");
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

    private File getFile(String currentPath, String path) {
        if (path.equals("\\")) {
            return fileManager.getAbsoluteFile(Constants.ABSOLUTE_FRONT_STRING);
        }

        if (fileManager.isAbsolute(path)) {  // 절대 경로일 때
            return fileManager.getAbsoluteFile(path);
        }

        // 상대 경로일 때
        return fileManager.getRelativeFile(currentPath, path);
    }
}
