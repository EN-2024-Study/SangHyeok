package observer;

import controller.CommandValidator;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;

public class Cls implements IObserver {

    private CommandValidator commandValidator;

    public Cls(CommandValidator commandValidator) {
        this.commandValidator = commandValidator;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (commandValidator.hasClsValue(command) != Constants.ValidType.Valid) {
            return;
        }

        for (int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }
}

