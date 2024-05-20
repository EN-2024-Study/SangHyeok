package client;

import observable.CmdManager;
import observer.*;
import observer.Exception;

public class Client {

    private CmdManager cmdManager;

    public Client() {
        this.cmdManager = new CmdManager();
        initCmdManager();
        this.cmdManager.run();
    }

    private void initCmdManager() {
        cmdManager.addObserver(new Cd());
        cmdManager.addObserver(new Cls());
        cmdManager.addObserver(new Copy());
        cmdManager.addObserver(new Dir());
        cmdManager.addObserver(new Help());
        cmdManager.addObserver(new Move());
        cmdManager.addObserver(new Exception());
    }
}