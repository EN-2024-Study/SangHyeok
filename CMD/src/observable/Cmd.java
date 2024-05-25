package observable;

import controller.CommandValidator;
import controller.StringFormatter;
import interfaces.IObservable;
import interfaces.IObserver;
import utility.Constants;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Cmd implements IObservable {

    private List<IObserver> observers;
    private CommandValidator commandValidator;
    private String currentPath;
    private boolean isRun;

    public Cmd(CommandValidator commandValidator) {
        this.observers = new ArrayList<>();
        this.commandValidator = commandValidator;
        this.currentPath = System.getProperty(Constants.INITIAL_PATH) + ">";
        this.isRun = true;
        printVersion();
    }

    @Override
    public void addObserver(IObserver o) {
        if (o == null || observers.contains(o)) {
            return;
        }
        observers.add(o);
    }

    @Override
    public void notifyObservers(String arg) {
        for (IObserver o : observers) {
            o.update(this, arg);
        }
    }

    public void run() {
        Scanner scanner = new Scanner(System.in);

        while(isRun) {
            System.out.print(currentPath);
            String command = scanner.nextLine();
            command = StringFormatter.trimCommand(command);

            if (!isCommandValid(command)) {
                continue;
            }

            notifyObservers(command);
        }
    }

    public void setCurrentPath(String path) {
        this.currentPath = path;
    }

    public void exit() {
        this.isRun = false;
    }

    public String getCurrentPath() {
        return this.currentPath.replace(">", "");
    }

    private boolean isCommandValid(String command) {
        if (commandValidator.hasCdValid(command) == Constants.ValidType.Valid)
            return true;
        if (commandValidator.hasClsValid(command) == Constants.ValidType.Valid)
            return true;
        if (commandValidator.hasCopyValid(command) == Constants.ValidType.Valid)
            return true;
        if (commandValidator.hasDirValid(command) == Constants.ValidType.Valid)
            return true;
        if (commandValidator.hasExitValid(command) == Constants.ValidType.Valid)
            return true;
        if (commandValidator.hasHelpValid(command) == Constants.ValidType.Valid)
            return true;
        if (commandValidator.hasMoveValid(command) == Constants.ValidType.Valid)
            return true;

        switch(commandValidator.hasMoveValid(command)) {
            case WrongCommand -> System.out.println("'" + command + "'" + Constants.WRONG_COMMAND);
            case WrongCommandSyntax -> System.out.println(Constants.WRONG_COMMAND_SYNTAX);
        }

        return false;
    }

    private void printVersion() {
        ProcessBuilder processBuilder = new ProcessBuilder(Constants.CMD_EXE, Constants.CMD_EXE_EXIT, Constants.CMD_VERSION);

        try {
            Process process = processBuilder.start();
            BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream(), Constants.ENCODING_STRING));

            reader.readLine();
            System.out.println(reader.readLine());

            process.waitFor();
        } catch (Exception e) {
            e.printStackTrace();
        }

        System.out.println(Constants.BUILD_STRING);
    }
}