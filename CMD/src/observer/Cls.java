package observer;

import controller.CommandValidator;
import interfaces.IObserver;
import observable.Cmd;

public class Cls implements IObserver {

    private CommandValidator commandValidator;

    public Cls(CommandValidator commandValidator) {
        this.commandValidator = commandValidator;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandValidator.isClsValid(command)) {
            return;
        }

        for (int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }
}

