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
        if (!Constants.COMMANDS[1].equals(command.charAt(0) + "" + command.charAt(1) + command.charAt(2)))
            return false;

        if (command.length() > 3) {
            for(Character c : Constants.VALID_ADDITION_COMMANDS) {
                if (c == command.charAt(3))
                    return true;
            }
            return false;
        }
        return true;
    }
}

