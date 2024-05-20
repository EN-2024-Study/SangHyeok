package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

import java.io.IOException;

public class Cls implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!command.equals(Constants.COMMANDS[1])) {
            return;
        }

        
    }
}
