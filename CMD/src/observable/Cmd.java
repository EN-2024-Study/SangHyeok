package observable;

import controller.CommandExceptionManager;
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
    private CommandExceptionManager commandExceptionManager;
    private String currentPath;
    private boolean isRun;

    public Cmd(CommandExceptionManager commandExceptionManager) {
        this.observers = new ArrayList<>();
        this.commandExceptionManager = commandExceptionManager;
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
            command = trimCommand(command);

            if (!isCommandValid(command)) {
                System.out.println("'" + command + "'" + Constants.WRONG_COMMAND);
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

    private boolean isCommandValid(String command) {
        if (commandExceptionManager.isCdValid(command))
            return true;
        if (commandExceptionManager.isClsValid(command))
            return true;
        if (commandExceptionManager.isCopyValid(command))
            return true;
        if (commandExceptionManager.isDirValid(command))
            return true;
        if (commandExceptionManager.isExitValid(command))
            return true;
        if (commandExceptionManager.isHelpValid(command))
            return true;

        return commandExceptionManager.isMoveValid(command);
    }

    private String trimCommand(String command) {
        command = command.trim();
        command = command.toLowerCase();
        command = command.replace(",", "");
        return command.replace("c:", "C:");
    }
}