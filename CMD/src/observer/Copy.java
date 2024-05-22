package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import controller.FileManager;

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

    }
}
