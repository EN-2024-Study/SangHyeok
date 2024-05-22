package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.CmdManager;
import controller.PathManager;

public class Copy implements IObserver {

    protected PathManager pathManager;
    protected ExceptionManager exceptionManager;

    public Copy(ExceptionManager exceptionManager, PathManager pathManager) {
        this.exceptionManager = exceptionManager;
        this.pathManager = pathManager;
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!exceptionManager.isCopyValid(command)) {
            return;
        }

    }
}
