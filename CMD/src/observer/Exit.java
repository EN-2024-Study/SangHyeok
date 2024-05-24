package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;

public class Exit implements IObserver {

    private CommandExceptionManager commandExceptionManager;

    public Exit(CommandExceptionManager commandExceptionManager) {
        this.commandExceptionManager = commandExceptionManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isExitValid(command)) {
            return;
        }

        cmd.exit();
    }
}
