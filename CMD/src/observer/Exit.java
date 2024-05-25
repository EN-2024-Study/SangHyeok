package observer;

import controller.CommandValidCheck;
import interfaces.IObserver;
import observable.Cmd;

public class Exit implements IObserver {

    private CommandValidCheck commandValidCheck;

    public Exit(CommandValidCheck commandValidCheck) {
        this.commandValidCheck = commandValidCheck;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandValidCheck.isExitValid(command)) {
            return;
        }

        cmd.exit();
    }
}
