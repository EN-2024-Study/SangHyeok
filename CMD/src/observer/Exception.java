package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

public class Exception implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (isCommandValid(command)) {
            return;
        }

        if (command.equals(Constants.EXIT)) {
            cmdManager.exit();
            return;
        }


    }

    private boolean isCommandValid(String command) {
        for(String s : Constants.COMMANDS) {
            if (s.contains(command)) {
                return true;
            }
        }
        return false;
    }
}
