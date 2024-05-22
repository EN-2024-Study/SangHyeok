package client;

import controller.ExceptionManager;
import observable.CmdManager;
import observer.*;
import observer.Exit;
import controller.PathManager;

public class Client {

    private CmdManager cmdManager;

    public Client() {
        ExceptionManager exceptionManager = new ExceptionManager();
        this.cmdManager = new CmdManager(exceptionManager);

        initCmdManager(exceptionManager);
        this.cmdManager.run();
    }

    private void initCmdManager(ExceptionManager exceptionManager) {
        PathManager pathManager = new PathManager();

        cmdManager.addObserver(new Cd(exceptionManager, pathManager));
        cmdManager.addObserver(new Copy(exceptionManager, pathManager));
        cmdManager.addObserver(new Dir(exceptionManager, pathManager));
        cmdManager.addObserver(new Move(exceptionManager, pathManager));
        cmdManager.addObserver(new Cls(exceptionManager));
        cmdManager.addObserver(new Help(exceptionManager));
        cmdManager.addObserver(new Exit(exceptionManager));
    }
}