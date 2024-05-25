package controller;

import utility.Constants;

public class CommandValidator {

    public Constants.ValidType hasCdValue(String command) {
        return hasCommandValue(command.replace("/", "\\"), Constants.COMMANDS[0]);
    }

    public Constants.ValidType hasClsValue(String command) {
        return hasCommandValue(command, Constants.COMMANDS[1]);
    }

    public Constants.ValidType hasCopyValue(String command) {
        return hasCommandValue(command, Constants.COMMANDS[2]);
    }

    public Constants.ValidType hasDirValue(String command) {
        return hasCommandValue(command, Constants.COMMANDS[3]);
    }

    public Constants.ValidType hasExitValue(String command) {
        return hasCommandValue(command, Constants.COMMANDS[4]);
    }

    public Constants.ValidType hasHelpValue(String command) {
        return hasCommandValue(command, Constants.COMMANDS[5]);
    }

    public Constants.ValidType hasMoveValue(String command) {
        return hasCommandValue(command, Constants.COMMANDS[6]);
    }

    private Constants.ValidType hasCommandValue(String command, String constant) {
        StringBuilder front = new StringBuilder();

        if (command.length() < constant.length()) {
            return Constants.ValidType.WrongCommand;
        }

        for (int i = 0; i < constant.length(); i++) {
            front.append(command.charAt(i));
        }

        if (front.toString().equals(constant)) {    // 올바른 명령이면
            return hasPathValue(command);
        }

        return Constants.ValidType.WrongCommand;
    }

    private Constants.ValidType hasPathValue(String command) {
        for (Character c : Constants.INVALID_ADDITION_COMMANDS) {
            if (command.contains(c + "")) {
                return Constants.ValidType.WrongCommandSyntax;
            }
        }
        return Constants.ValidType.Valid;
    }
}
