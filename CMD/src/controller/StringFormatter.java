package controller;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class StringFormatter {

    public static String getBackspace(int length) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < length; i++) {
            result.append("\b");
        }
        return result.toString();
    }

    public static String getTimeInfo(long time) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd a hh:mm");
        return dateFormat.format(new Date(time));
    }

    public static String getCommaNumber(long number) {
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        return decimalFormat.format(number);
    }

    public static String removeCommand(String command, int startIndex) {
        StringBuilder result = new StringBuilder();

        for (int i = startIndex; i < command.length(); i++) {    // 명령어 제거
            result.append(command.charAt(i));
        }
        return result.toString().trim();
    }

    public static String trimCommand(String command) {
        command = command.trim();
        command = command.toLowerCase();
        command = command.replace(",", "");
        return command.replace("c:", "C:");
    }
}
