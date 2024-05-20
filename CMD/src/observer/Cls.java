package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

public class Cls implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!command.equals(Constants.COMMANDS[1])) {
            return;
        }

        for(int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }
}
