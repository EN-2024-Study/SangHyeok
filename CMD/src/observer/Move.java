package observer;

import observable.CmdManager;
import controller.PathManager;

public class Move extends Copy {

    public Move(PathManager pathManager) {
        super(pathManager);
    }

    @Override
    public void update(CmdManager o, String arg) {
        super.update(o, arg);

    }
}
