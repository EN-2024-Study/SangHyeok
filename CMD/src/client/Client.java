package client;

import controller.CommandValidator;
import observable.Cmd;
import observer.*;
import observer.Exit;
import controller.FileProvider;

public class Client {

    private Cmd cmd;

    public Client() {
        CommandValidator commandValidator = new CommandValidator();
        this.cmd = new Cmd(commandValidator);

        initCmdManager(commandValidator);
        this.cmd.run();
    }

    private void initCmdManager(CommandValidator commandValidator) {
        FileProvider fileProvider = new FileProvider();

        cmd.addObserver(new Cd(commandValidator, fileProvider));
        cmd.addObserver(new Copy(commandValidator, fileProvider));
        cmd.addObserver(new Dir(commandValidator, fileProvider));
        cmd.addObserver(new Move(commandValidator, fileProvider));
        cmd.addObserver(new Cls(commandValidator));
        cmd.addObserver(new Help(commandValidator));
        cmd.addObserver(new Exit(commandValidator));
    }
}