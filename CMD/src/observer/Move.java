package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import controller.FileManager;

public class Move implements IObserver {

    private ExceptionManager exceptionManager;
    private FileManager fileManager;

    public Move(ExceptionManager exceptionManager, FileManager fileManager) {
        this.exceptionManager = exceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!exceptionManager.isMoveValid(command)) {
            return;
        }

    }
}
