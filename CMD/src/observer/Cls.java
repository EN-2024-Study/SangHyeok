package observer;

import controller.CommandValidCheck;
import interfaces.IObserver;
import observable.Cmd;

public class Cls implements IObserver {

    private CommandValidCheck commandValidCheck;

    public Cls(CommandValidCheck commandValidCheck) {
        this.commandValidCheck = commandValidCheck;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandValidCheck.isClsValid(command)) {
            return;
        }

        for (int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }
}

