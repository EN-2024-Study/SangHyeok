package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import controller.FileManager;

import java.io.File;

public class Copy implements IObserver {

    protected FileManager fileManager;
    protected ExceptionManager exceptionManager;

    public Copy(ExceptionManager exceptionManager, FileManager fileManager) {
        this.exceptionManager = exceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!exceptionManager.isCopyValid(command)) {
            return;
        }

        processCommand(cmd, command);
    }

    private void processCommand(Cmd cmd, String command) {
        File currentFile = new File(cmd.getCurrentPath().replace(">", ""));
        String[] paths = fileManager.getTwoPath(command);

        if (command.length() < 5 || paths == null) {

        }

        if (paths.length == 1) {

        } else if (paths.length == 2) {

        }


    }
}
