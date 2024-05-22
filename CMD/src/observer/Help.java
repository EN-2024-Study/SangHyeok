package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

import java.io.*;

public class Help implements IObserver {

    private File file;
    private ExceptionManager exceptionManager;

    public Help(ExceptionManager exceptionManager) {
        this.exceptionManager = exceptionManager;
        this.file = new File(Constants.HELP_PATH);
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!exceptionManager.isHelpValid(command)) {
            return;
        }

        try {
            FileReader fileReader = new FileReader(file);
            int cur = 0;

            while((cur = fileReader.read()) != -1){
                System.out.print((char)cur);
            }

            fileReader.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        System.out.println();
    }
}
