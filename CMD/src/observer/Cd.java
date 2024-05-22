package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;
import controller.PathManager;

import java.io.File;
import java.io.IOException;

public class Cd implements IObserver {

    private PathManager pathManager;

    public Cd(PathManager pathManager) {
        this.pathManager = pathManager;
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!isCommandValid(command)) {
            return;
        }

        String path = getTrimCommand(command);
        if (isProcessException(cmdManager.getCurrentPath(), path))
            return;

        File currentDirectory = getFile(cmdManager.getCurrentPath(), path);
        if (!pathManager.isPathValid(currentDirectory)) {  // 유효한 경로가 아닐 때
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmdManager.setCurrentPath(currentDirectory + ">");
    }

    private boolean isCommandValid(String command) {
        return command.length() >= 2 && Constants.COMMANDS[0].equals(command.charAt(0) + "" + command.charAt(1));
    }

    private String getTrimCommand(String command) {
        StringBuilder result = new StringBuilder();
        command = command.replace(" ", "");
        command = command.replace("c:", "C:");
        command = command.replace("/", "\\");
        for(int i = 2; i < command.length(); i++) {    // cd 명령어 제거
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
            switch(path.charAt(0)) {
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

    private File getFile(String currentPath, String path) {
        if (path.equals("\\")) {
            return new File(Constants.ABSOLUTE_FRONT_STRING);
        }

        if (pathManager.isAbsolute(path)) {  // 절대 경로일 때
            try {
                return new File(path).getCanonicalFile();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        } else {    // 상대 경로일 때
            return pathManager.getRelativeFile(currentPath, path);
        }
    }
}
