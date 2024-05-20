package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

import java.io.File;
import java.io.IOException;

public class Cd implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!command.contains(Constants.COMMANDS[0]))
            return;

        if (!isCommandValid(command)) {
            return;     // 기능 구현 후 예외처리 하기
        }

        File currentDirectory;
        String path = getTrimCommand(command);

        if (isAbsolute(path)) {  // 절대 경로일 때
            currentDirectory = new File(path);
        } else {    // 상대 경로일 때
            currentDirectory = getRelativeFile(cmdManager.getCurrentPath(), path);
        }

        if (!isPathValid(currentDirectory)) {  // 유효한 경로가 아닐 때
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmdManager.setCurrentPath(currentDirectory + ">");
    }

    private boolean isCommandValid(String command) {
        if (command.length() < 4 || command.charAt(2) != ' ') {
            return false;
        }

        return command.charAt(0) == 'c' && command.charAt(1) == 'd';
    }

    private boolean isAbsolute(String command) {
        return command.contains(Constants.ABSOLUTE_FRONT_STRING);
    }

    private boolean isPathValid(File path) {
        return path.exists() && path.isDirectory();
    }

    // 상대경로
    private File getRelativeFile(String pastPath, String path) {
        String currentPath = pastPath.replace(">", "\\");
        currentPath += path;
        currentPath = currentPath.replace("\\", "/");

        try {
            return new File(currentPath).getCanonicalFile();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private String getTrimCommand(String command) {
        String result = "";
        command = command.replace(" ", "");

        for(int i = 2; i < command.length(); i++) {    // cd 명령어 제거
            result += command.charAt(i);
        }

        return getTrimPath(result);
    }

    private String getTrimPath(String path) {
        String result = path.replace("/", "\\");
        result = result.replace("c:\\", "C:\\");
        result = result.replace("\\users", "\\Users");
        result = result.replace("\\desktop", "\\Desktop");
        result = result.replace("\\en#스터디", "\\EN#스터디");
        return result;
    }
}
