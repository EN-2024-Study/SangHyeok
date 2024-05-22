package observer;

import controller.ExceptionManager;
import observable.Cmd;
import controller.FileManager;

public class Move extends Copy {

    public Move(ExceptionManager exceptionManager, FileManager fileManager) {
        super(exceptionManager, fileManager);
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!super.exceptionManager.isMoveValid(command)) {
            return;
        }

    }
}
