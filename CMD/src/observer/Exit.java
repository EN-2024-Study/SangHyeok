package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

public class Exit implements IObserver {

    private ExceptionManager exceptionManager;

    public Exit(ExceptionManager exceptionManager) {
        this.exceptionManager = exceptionManager;
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!exceptionManager.isExitValid(command)) {
            return;
        }

        if (command.equals(Constants.COMMANDS[6])) {
            cmdManager.exit();
        }
    }
}
