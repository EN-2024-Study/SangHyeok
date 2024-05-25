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

    @Override
    public void run() {
        Scanner scanner = new Scanner(System.in);

        while(isRun) {
            System.out.print(currentPath);
            String command = scanner.nextLine();
            command = StringFormatter.trimCommand(command);

            if (!processCommandIfValid(command)) {
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

    /*
    observer pattern 은 CMD project 에 매우 비효율 적인 패턴 인 것 같습니다.
    run()에서 올바른 명령어인지 확인 후 각 명령어 Class 에 넘겨주면
    또 각각의 명령어 Class 에서 자기 것의 명령어인지 한번 더 확인하는 과정이 있어서 비효율 적이라고 생각합니다.
     */
    private boolean processCommandIfValid(String command) {
        Constants.ValidType[] valueTypes = commandValidator.hasAllCommandValue(command);

        if (command.isEmpty())
            return false;

        for(Constants.ValidType value : valueTypes) {
            switch(value) {
                case Valid -> {
                    return true;
                }
                case WrongCommandSyntax -> {
                    System.out.println(Constants.WRONG_COMMAND_SYNTAX);
                    return false;
                }
            }
        }

        //======== valueType == Wrong_Command =======//
        System.out.println("'" + command + "'" + Constants.WRONG_COMMAND);
        return false;
    }
}