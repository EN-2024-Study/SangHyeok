package observable;

import controller.ExceptionManager;
import interfaces.IObservable;
import interfaces.IObserver;
import utility.Constants;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class CmdManager implements IObservable {

    private List<IObserver> observers;
    private ExceptionManager exceptionManager;
    private String currentPath;
    private String command;
    private boolean isRun;

    public CmdManager(ExceptionManager exceptionManager) {
        this.observers = new ArrayList<IObserver>();
        this.exceptionManager = exceptionManager;
        this.currentPath = Constants.INITIAL_ROUTE;
        this.command = "";
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
            command = scanner.nextLine();

            trimCommand();
            if (!isCommandValid()) {
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
        return this.currentPath;
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

    private boolean isCommandValid() {
        if (exceptionManager.isCdValid(command))
            return true;
        if (exceptionManager.isClsValid(command))
            return true;
        if (exceptionManager.isCopyValid(command))
            return true;
        if (exceptionManager.isDirValid(command))
            return true;
        if (exceptionManager.isExitValid(command))
            return true;
        if (exceptionManager.isHelpValid(command))
            return true;

        return exceptionManager.isMoveValid(command);
    }

    private void trimCommand() {
        command = command.trim();
        command = command.toLowerCase();
        command = command.replace("/", "\\");
        command = command.replace(",", "");
        command = command.replace("\"", "");
    }
}