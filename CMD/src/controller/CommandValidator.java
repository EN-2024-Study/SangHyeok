package controller;

import utility.Constants;

public class CommandValidator {

    public Constants.ValidType[] hasAllCommandValue(String command) {
        Constants.ValidType[] valueTypes = new Constants.ValidType[7];
        valueTypes[0] = hasCdValue(command);
        valueTypes[1] = hasClsValue(command);
        valueTypes[2] = hasCopyValue(command);
        valueTypes[3] = hasDirValue(command);
        valueTypes[4] = hasExitValue(command);
        valueTypes[5] = hasHelpValue(command);
        valueTypes[6] = hasMoveValue(command);
        return valueTypes;
    }

    public Constants.ValidType hasCdValue(String command) {
        String result = command.replace("/", "\\");
        if (result.length() > 2 && (result.charAt(2) == '.' || result.charAt(2) == '\\')) {
            result = result.substring(0, 2) + " " + result.substring(2);
        }
        return hasCommandValue(result, Constants.COMMANDS[0]);
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

            for(Character c : Constants.INVALID_ADDITION_COMMANDS) {
                if (command.contains(c + "")) {
                    return Constants.ValidType.WrongCommandSyntax;
                }
            }

            return Constants.ValidType.WrongCommand;
        }

        //===== 명령어 길이 만족 후 =====//

        for (int i = 0; i < constant.length(); i++) {
            front.append(command.charAt(i));
        }

        if (!front.toString().equals(constant)) {
            return Constants.ValidType.WrongCommand;
        }

        if (command.length() > front.length()) {    // 경로가 존재한다면
            if (command.charAt(constant.length()) == ' ')
                return hasPathValue(command);
            return Constants.ValidType.WrongCommand;
        }

        return hasPathValue(command);
    }

    private Constants.ValidType hasPathValue(String command) {
        for (Character c : Constants.INVALID_ADDITION_COMMANDS) {
            if (command.contains(c + "")) {
                return Constants.ValidType.WrongCommandSyntax;
            }
        }

        if (!command.contains(Constants.ABSOLUTE_FRONT_STRING) && command.contains(":")) {
            return Constants.ValidType.WrongCommand;
        }

        return Constants.ValidType.Valid;
    }
}
