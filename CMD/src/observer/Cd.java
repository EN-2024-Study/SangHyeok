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

        String path = getRemovedCommand(command);
        if (isProcessException(cmd.getCurrentPath(), path))
            return;

        processCommand(cmd, path);
    }

    private String getRemovedCommand(String command) {
        StringBuilder result = new StringBuilder();
        command = command.replace(" ", "");

        for (int i = 2; i < command.length(); i++) {    // cd 명령어 제거
            result.append(command.charAt(i));
        }

        return result.toString();
    }

    private boolean isProcessException(String currentPath, String path) {
        if (path.isEmpty()) {
            System.out.println(currentPath);
            return true;
        }

        if (path.length() == 1) {
            switch (path.charAt(0)) {
                case ' ':
                case '=':
                case '&':
                    System.out.println(currentPath);
                    return true;
                case '.':
                    System.out.println();
                    return true;
                case '\\':
                    return false;
            }
        }
        return false;
    }

    private void processCommand(Cmd cmd, String path) {
        File currentDirectory = getFile(cmd.getCurrentPath(), path);

        if (!fileManager.isFileValid(currentDirectory)) {  // 유효한 경로가 아닐 때
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmd.setCurrentPath(currentDirectory + ">");
    }

    private File getFile(String currentPath, String path) {
        if (path.equals("\\")) {
            return new File(Constants.ABSOLUTE_FRONT_STRING);
        }

        if (fileManager.isAbsolute(path)) {  // 절대 경로일 때
            return fileManager.getAbsoluteFile(path);
        }

        // 상대 경로일 때
        return fileManager.getRelativeFile(currentPath, path);
    }
}
