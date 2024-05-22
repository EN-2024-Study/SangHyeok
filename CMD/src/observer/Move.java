package observer;

import controller.ExceptionManager;
import observable.CmdManager;
import controller.PathManager;

public class Move extends Copy {

    public Move(ExceptionManager exceptionManager, PathManager pathManager) {
        super(exceptionManager, pathManager);
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!super.exceptionManager.isMoveValid(command)) {
            return;
        }

    }
}
