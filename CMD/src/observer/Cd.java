package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

import java.io.File;

public class Cd implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!command.contains(Constants.COMMANDS[0]))
            return;

        if (!isCommandValid(command)) {
            return;     // 기능 구현 후 예외처리 하기
        }

        File rootDirectory;
        String path = getTrimPath(command);

        if (isAbsolute(path)) {  // 절대 경로일 때
            rootDirectory = getAbsoluteFile(path);
        } else {    // 상대 경로일 때
            rootDirectory = getRelativeFile(cmdManager.getCurrentPath(), path);
        }

        if (!isPathValid(rootDirectory)) {  // 유효한 경로가 아닐 때
            System.out.println(rootDirectory);
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmdManager.setCurrentPath(rootDirectory + ">");
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
        return path != null && path.exists() && path.isDirectory();
    }

    // 절대경로
    private File getAbsoluteFile(String path) {
        String result = path.replace("cd ", "");
        return new File(result);
    }

    // 상대경로
    private File getRelativeFile(String currentPath, String path) {
        String result = currentPath.replace(">", "\\");
        result += path.replace("cd ", "");
        return new File(result);
    }

    private String getTrimPath(String path) {
        String result = "";
        path = path.replace(" ", "");

        for(int i = 2; i < path.length(); i++) {    // cd 명령어 제거
            result += path.charAt(i);
        }

        result = result.replace("//", "\\");
        result = result.replace("c:\\", "C:\\");
        result = result.replace("\\users", "\\Users");
        result = result.replace("\\desktop", "\\Desktop");
        result = result.replace("\\en#스터디", "\\EN#스터디");
        return result;
    }
}
