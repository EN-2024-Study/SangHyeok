package observable;

import interfaces.IObservable;
import interfaces.IObserver;
import utility.Constants;

import java.io.BufferedReader;
import java.io.File;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class CmdManager implements IObservable {

    private List<IObserver> observers;
    private String currentPath;
    private String command;
    private boolean isRun;

    public CmdManager() {
        this.observers = new ArrayList<IObserver>();
        this.currentPath = Constants.INITIAL_ROUTE;
        this.command = "";
        this.isRun = true;
        printVersion();
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

    @Override
    public void addObserver(IObserver o) {
        if (o == null || observers.contains(o)) {
            System.out.println("객체가 null 이거나 이미 생성됨.");
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

    public void setCurrentPath(String path) {
        this.currentPath = path;
    }

    public String getCurrentPath() {
        return this.currentPath;
    }

    public void exit() {
        this.isRun = false;
    }

    public void run() {
        Scanner scanner = new Scanner(System.in);

        while(isRun) {
            System.out.print(currentPath);
            command = scanner.nextLine();
            command = getTrimCommand(command);

            notifyObservers(command);
        }
    }

    private String getTrimCommand(String command) {
        String result = command.toLowerCase();
        result = result.trim();
        return result.replace("\"", "");
    }
}