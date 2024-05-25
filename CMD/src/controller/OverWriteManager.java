package controller;

import utility.Constants;

import java.util.Scanner;

public class OverWriteManager {

    private Character answer;

    public OverWriteManager() {
        initAnswer();
    }

    protected void initAnswer() {
        this.answer = 'n';
    }

    protected boolean isProcessOverWrite(String targetPath) {
        // 기존 파일에 덮어씌울 때
        if (answer != 'a') {
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

        while(!whetherAnswer) {
            System.out.print(targetPath + Constants.WHETHER_OVER_WRITE);
            String answer = scanner.nextLine();
            answer = answer.toLowerCase();

            if (answer.isEmpty()) {
                continue;
            }

            switch(answer.charAt(0)) {
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
