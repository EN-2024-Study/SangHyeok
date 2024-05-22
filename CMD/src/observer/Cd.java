package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;
import utility.PathManager;

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
            return;     // 기능 구현 후 예외처리 하기
        }

        File currentDirectory;
        String path = getTrimCommand(command);

        if (pathManager.isAbsolute(path)) {  // 절대 경로일 때
            try {
                currentDirectory = new File(path).getCanonicalFile();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        } else {    // 상대 경로일 때
            currentDirectory = pathManager.getRelativeFile(cmdManager.getCurrentPath(), path);
        }

        if (!pathManager.isPathValid(currentDirectory)) {  // 유효한 경로가 아닐 때
            System.out.println(Constants.WRONG_PATH);
            return;
        }

        cmdManager.setCurrentPath(currentDirectory + ">");
    }

    private boolean isCommandValid(String command) {
        if (command.length() < 2 || !Constants.COMMANDS[0].equals(command.charAt(0) + "" + command.charAt(1)))
            return false;

        if (command.length() > 2) {
            for(Character c : Constants.VALID_ADDITION_COMMANDS) {
                if (c == command.charAt(2))
                    return true;
            }

            return command.charAt(2) == '/';
        }
        return true;
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
}
