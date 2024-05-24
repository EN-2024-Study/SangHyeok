package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;

public class Cls implements IObserver {

    private CommandExceptionManager commandExceptionManager;

    public Cls(CommandExceptionManager commandExceptionManager) {
        this.commandExceptionManager = commandExceptionManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isClsValid(command)) {
            return;
        }

        for (int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }
}

