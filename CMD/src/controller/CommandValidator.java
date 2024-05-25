package controller;

import utility.Constants;

public class CommandValidator {

    public Constants.ValidType hasCdValid(String command) {
        return hasCommandValid(command.replace("/", "\\"), Constants.COMMANDS[0]);
    }

    public Constants.ValidType hasClsValid(String command) {
        return hasCommandValid(command, Constants.COMMANDS[1]);
    }

    public Constants.ValidType hasCopyValid(String command) {
        return hasCommandValid(command, Constants.COMMANDS[2]);
    }

    public Constants.ValidType hasDirValid(String command) {
        return hasCommandValid(command, Constants.COMMANDS[3]);
    }

    public Constants.ValidType hasExitValid(String command) {
        return hasCommandValid(command, Constants.COMMANDS[4]);
    }

    public Constants.ValidType hasHelpValid(String command) {
        return hasCommandValid(command, Constants.COMMANDS[5]);
    }

    public Constants.ValidType hasMoveValid(String command) {
        return hasCommandValid(command, Constants.COMMANDS[6]);
    }

    private Constants.ValidType hasCommandValid(String command, String constant) {
        StringBuilder front = new StringBuilder();

        if (command.length() < constant.length()) {
            return Constants.ValidType.WrongCommand;
        }

        for (int i = 0; i < constant.length(); i++) {
            front.append(command.charAt(i));
        }

        if (front.toString().equals(constant)) {    // 올바른 명령이면
            return hasPathValid(command.substring(front.length() + 1));
        }

        return Constants.ValidType.WrongCommand;
    }

    private Constants.ValidType hasPathValid(String path) {
        for (Character c : Constants.INVALID_ADDITION_COMMANDS) {
            if (path.contains(c + "")) {
                return Constants.ValidType.WrongCommandSyntax;
            }
        }
        return Constants.ValidType.Valid;
    }
}
