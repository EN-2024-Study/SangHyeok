package observer;

import controller.CommandValidator;
import interfaces.IObserver;
import observable.Cmd;

public class Exit implements IObserver {

    private CommandValidator commandValidator;

    public Exit(CommandValidator commandValidator) {
        this.commandValidator = commandValidator;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandValidator.isExitValid(command)) {
            return;
        }

        cmd.exit();
    }
}
