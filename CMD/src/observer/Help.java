package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

import java.io.*;

public class Help implements IObserver {

    private File file;

    public Help() {
        this.file = new File(Constants.HELP_PATH);
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!command.equals(Constants.COMMANDS[4])) {
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
