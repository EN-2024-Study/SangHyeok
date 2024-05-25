package observer;

import controller.CommandValidator;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;

public class Exit implements IObserver {

    private CommandValidator commandValidator;

    public Exit(CommandValidator commandValidator) {
        this.commandValidator = commandValidator;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (commandValidator.hasExitValid(command) != Constants.ValidType.Valid) {
            return;
        }

        cmd.exit();
    }
}
