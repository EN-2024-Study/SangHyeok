package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import controller.FileManager;

public class Move implements IObserver {

    private CommandExceptionManager commandExceptionManager;
    private FileManager fileManager;

    public Move(CommandExceptionManager commandExceptionManager, FileManager fileManager) {
        this.commandExceptionManager = commandExceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isMoveValid(command)) {
            return;
        }

    }
}
