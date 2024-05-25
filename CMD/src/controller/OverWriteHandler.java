package controller;

import utility.Constants;

import java.util.Scanner;

public class OverWriteHandler {

    private Character answer;

    public OverWriteHandler() {
        initAnswer();
    }

    protected void initAnswer() {
        this.answer = 'n';
    }

    protected boolean isOverwriteConfirmed(String targetPath, boolean isSourceDirectory) {
        if (isSourceDirectory) {
            if (answer == 'n') {
                answer = whetherOverWrite(targetPath);
            }
        } else if (answer != 'a') {
            answer = whetherOverWrite(targetPath);
        }

        return switch (answer) {
            case 'y', 'a' -> true;
            default -> false;
        };
    }

    private Character whetherOverWrite(String targetPath) {
        Scanner scanner = new Scanner(System.in);
        boolean whetherAnswer = false;

        while (!whetherAnswer) {
            System.out.print(targetPath + Constants.WHETHER_OVER_WRITE);
            String inputString = scanner.nextLine();
            answer = inputString.trim().toLowerCase().charAt(0);

            if (inputString.isEmpty()) {
                continue;
            }

            switch (answer) {
                case 'y' -> {
                    return 'y';
                }
                case 'n' -> {
                    return 'n';
                }
                case 'a' -> {
                    return 'a';
                }
            }
        }
        return 'n';
    }
}
