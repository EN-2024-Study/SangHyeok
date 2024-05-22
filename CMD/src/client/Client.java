package client;

import controller.ExceptionManager;
import observable.Cmd;
import observer.*;
import observer.Exit;
import controller.FileManager;

public class Client {

    private Cmd cmd;

    public Client() {
        ExceptionManager exceptionManager = new ExceptionManager();
        this.cmd = new Cmd(exceptionManager);

        initCmdManager(exceptionManager);
        this.cmd.run();
    }

    private void initCmdManager(ExceptionManager exceptionManager) {
        FileManager fileManager = new FileManager();

        cmd.addObserver(new Cd(exceptionManager, fileManager));
        cmd.addObserver(new Copy(exceptionManager, fileManager));
        cmd.addObserver(new Dir(exceptionManager, fileManager));
        cmd.addObserver(new Move(exceptionManager, fileManager));
        cmd.addObserver(new Cls(exceptionManager));
        cmd.addObserver(new Help(exceptionManager));
        cmd.addObserver(new Exit(exceptionManager));
    }
}