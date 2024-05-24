package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import controller.FileManager;
import utility.Constants;

import java.io.File;

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
        File currentFile = new File(cmd.getCurrentPath().replace(">", ""));
        File targetFile = null;
        File replaceFile = null;
        String inputPath = fileManager.removeCommand(command, Constants.COMMANDS[2].length());

        // 명령어만 존재할 때
        if (command.length() < 5 || inputPath.isEmpty()) {
            System.out.println(Constants.WRONG_COMMAND2);
            return;
        }

        // 두개의 경로가 존재할 때
        if (fileManager.isTwoPaths(inputPath)) {
            File[] files = fileManager.getTwoFiles(inputPath);
            targetFile = fileManager.getFile(currentFile.toString(), files[0].toString());
            replaceFile = fileManager.getFile(currentFile.toString(), files[1].toString());

        } else {    // 하나의 경로만 존재할 때
            targetFile = fileManager.getFile(currentFile.toString(), inputPath);
        }

        if (!targetFile.exists()) {
            System.out.println(Constants.WRONG_DIRECTOR);
            return;
        }


    }
}
