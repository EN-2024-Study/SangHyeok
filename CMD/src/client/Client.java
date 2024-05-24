package client;

import controller.CommandExceptionManager;
import observable.Cmd;
import observer.*;
import observer.Exit;
import controller.FileManager;

public class Client {

    private Cmd cmd;

    public Client() {
        CommandExceptionManager commandExceptionManager = new CommandExceptionManager();
        this.cmd = new Cmd(commandExceptionManager);

        initCmdManager(commandExceptionManager);
        this.cmd.run();
    }

    private void initCmdManager(CommandExceptionManager commandExceptionManager) {
        FileManager fileManager = new FileManager();

        cmd.addObserver(new Cd(commandExceptionManager, fileManager));
        cmd.addObserver(new Copy(commandExceptionManager, fileManager));
        cmd.addObserver(new Dir(commandExceptionManager, fileManager));
        cmd.addObserver(new Move(commandExceptionManager, fileManager));
        cmd.addObserver(new Cls(commandExceptionManager));
        cmd.addObserver(new Help(commandExceptionManager));
        cmd.addObserver(new Exit(commandExceptionManager));
    }
}