package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;

public class Exception implements IObserver {

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (isCommandValid(command))
            return;

        if (command.equals(Constants.EXIT)) {
            cmdManager.exit();
            return;
        }

        System.out.println("'" + command + "'" + Constants.WRONG_COMMAND);
    }

    private boolean isCommandValid(String command) {
        if (command.length() > 3) { // copy, move, help
            String result = command.charAt(0) + "" + command.charAt(1) + "" + command.charAt(2) + "" + command.charAt(3);
            return result.equals(Constants.COMMANDS[2]) || result.equals(Constants.COMMANDS[4]) || result.equals(Constants.COMMANDS[5]);

        } else if (command.length() > 2) {  // cls, dir
            String result = command.charAt(0) + "" + command.charAt(1) + "" + command.charAt(2);
            return result.equals(Constants.COMMANDS[1]) || result.equals(Constants.COMMANDS[3]);

        } else if (command.length() == 2) { // cd
            return Constants.COMMANDS[0].equals(command.charAt(0) + "" + command.charAt(1));
        }
        return false;
    }
}
