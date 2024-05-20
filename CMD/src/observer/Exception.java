package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

public class Exception implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (isExitValid(cmdManager, command)) {
            return;
        }


    }

    private boolean isExitValid(CmdManager cmdManager, String command) {
        if (command.equals(Constants.EXIT)) {
            cmdManager.exit();
            return true;
        }
        return false;
    }
}
