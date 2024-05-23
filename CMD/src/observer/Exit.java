package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;

public class Exit implements IObserver {

    private ExceptionManager exceptionManager;

    public Exit(ExceptionManager exceptionManager) {
        this.exceptionManager = exceptionManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!exceptionManager.isExitValid(command)) {
            return;
        }

        cmd.exit();
    }
}
