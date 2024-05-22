package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

public class Cls implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!isCommandValid(command)) {
            return;
        }

        for (int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }

    private boolean isCommandValid(String command) {
        return Constants.COMMANDS[1].equals(String.valueOf(command.charAt(0) + command.charAt(1) + command.charAt(2)));
    }
}

