package controller;

import utility.Constants;

public class CommandValidCheck {

    public boolean isCdValid(String command) {
        if (command.length() < 2) {
            return false;
        }
        return isCommandValid(command.replace("/", "\\"), Constants.COMMANDS[0]);
    }

    public boolean isClsValid(String command) {
        if (command.length() < 3) {
            return false;
        }
        return isCommandValid(command, Constants.COMMANDS[1]);
    }

    public boolean isCopyValid(String command) {
        if (command.length() < 4) {
            return false;
        }
        return isCommandValid(command, Constants.COMMANDS[2]);
    }

    public boolean isDirValid(String command) {
        if (command.length() < 3) {
            return false;
        }
        return isCommandValid(command, Constants.COMMANDS[3]);
    }

    public boolean isExitValid(String command) {
        if (command.length() < 4) {
            return false;
        }
        return isCommandValid(command, Constants.COMMANDS[4]);
    }

    public boolean isHelpValid(String command) {
        if (command.length() < 4) {
            return false;
        }
        return isCommandValid(command, Constants.COMMANDS[5]);
    }

    public boolean isMoveValid(String command) {
        if (command.length() < 4) {
            return false;
        }
        return isCommandValid(command, Constants.COMMANDS[6]);
    }

    private boolean isCommandValid(String command, String constant) {
        StringBuilder front = new StringBuilder();

        for(int i = 0; i < constant.length(); i++) {
            front.append(command.charAt(i));
        }

        if (front.toString().equals(constant)) {    // 올바른 명령어이면
            if (constant.length() < command.length()) { // 입력받은 값이 명령어 길이보다 길다면
                return isBackCommandValid(command.charAt(constant.length()));
            }
            return true;
        }
        return false;
    }

    private boolean isBackCommandValid(Character back) {
        for (Character c : Constants.VALID_ADDITION_COMMANDS) {
            if (back == c)
                return true;
        }
        return false;
    }
}
