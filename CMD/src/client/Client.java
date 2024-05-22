package client;

import observable.CmdManager;
import observer.*;
import observer.Exception;
import controller.PathManager;

public class Client {

    public Client() {
        CmdManager cmdManager = new CmdManager();
        initCmdManager(cmdManager);
        cmdManager.run();
    }

    private void initCmdManager(CmdManager cmdManager) {
        PathManager pathManager = new PathManager();

        cmdManager.addObserver(new Cd(pathManager));
        cmdManager.addObserver(new Copy(pathManager));
        cmdManager.addObserver(new Dir(pathManager));
        cmdManager.addObserver(new Move(pathManager));
        cmdManager.addObserver(new Cls());
        cmdManager.addObserver(new Help());
        cmdManager.addObserver(new Exception());
    }
}