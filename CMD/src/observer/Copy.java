package observer;

import interfaces.IObserver;
import observable.CmdManager;
import controller.PathManager;

public class Copy implements IObserver {

    private PathManager pathManager;

    public Copy(PathManager pathManager) {
        this.pathManager = pathManager;
    }

    @Override
    public void update(CmdManager o, String arg) {

    }
}
