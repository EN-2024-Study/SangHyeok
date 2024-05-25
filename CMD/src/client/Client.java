package client;

import controller.CommandValidCheck;
import observable.Cmd;
import observer.*;
import observer.Exit;
import controller.FileManager;

public class Client {

    private Cmd cmd;

    public Client() {
        CommandValidCheck commandValidCheck = new CommandValidCheck();
        this.cmd = new Cmd(commandValidCheck);

        initCmdManager(commandValidCheck);
        this.cmd.run();
    }

    private void initCmdManager(CommandValidCheck commandValidCheck) {
        FileManager fileManager = new FileManager();

        cmd.addObserver(new Cd(commandValidCheck, fileManager));
        cmd.addObserver(new Copy(commandValidCheck, fileManager));
        cmd.addObserver(new Dir(commandValidCheck, fileManager));
        cmd.addObserver(new Move(commandValidCheck, fileManager));
        cmd.addObserver(new Cls(commandValidCheck));
        cmd.addObserver(new Help(commandValidCheck));
        cmd.addObserver(new Exit(commandValidCheck));
    }
}