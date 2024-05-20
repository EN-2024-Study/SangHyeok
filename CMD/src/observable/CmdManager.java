package observable;

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
    private String currentRoute;
    private String command;
    private boolean isRun;

    public CmdManager() {
        observers = new ArrayList<IObserver>();
        currentRoute = Constants.INITIAL_ROUTE;
        command = "";
        isRun = true;
        printInitial();
    }

    private void printInitial() {
        try {
            ProcessBuilder processBuilder = new ProcessBuilder(Constants.CMD_EXE, Constants.BUILD_EXIT, Constants.CMD_VERSION);
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

    public void setCommand(String command) {
        this.command = command;
    }

    public void setCurrentRoute(String route) {
        this.currentRoute = route;
    }

    public void exit() {
        this.isRun = false;
    }

    public void run() {
        Scanner scanner = new Scanner(System.in);
        while(isRun) {
            System.out.print(currentRoute);
            command = scanner.nextLine();
            notifyObservers(command);
        }
    }
}