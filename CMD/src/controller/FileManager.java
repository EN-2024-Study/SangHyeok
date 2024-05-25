package controller;

import utility.Constants;
import utility.StringManager;

import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class FileManager {

    public boolean isTwoPaths(String path) {
        if (!path.contains(" ")) {
            return false;
        }

        int count = StringManager.getQuotesCount(path);
        if (count >= 2) {   // 쌍 따움표가 존재할 때
            return path.contains("\" ") || path.contains(" \"");
        }

        return true;    // 쌍 따움표가 없고 공백 하나만 존재할 때
    }

    private boolean isAbsolute(String command) {
        if (command.length() < 3) {
            return false;
        }

        String result = command.substring(0, 3);
        return result.equals(Constants.ABSOLUTE_FRONT_STRING);
    }

    public String removeCommand(String command, int startIndex) {
        StringBuilder result = new StringBuilder();

        for (int i = startIndex; i < command.length(); i++) {    // 명령어 제거
            result.append(command.charAt(i));
        }
        return result.toString().trim();
    }

    public File getFile(String pastPath, String path) {
        if (isAbsolute(path)) {
            return getAbsoluteFile(path);
        } else {
            return getRelativeFile(pastPath, path);
        }
    }

    public File getAbsoluteFile(String path) {
        try {
            return new File(path).getCanonicalFile();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    private File getRelativeFile(String pastPath, String path) {
        String currentPath = pastPath + "\\";
        currentPath += path;

        return getAbsoluteFile(currentPath);
    }

    public String[] getTwoPaths(String path) {
        int count = StringManager.getQuotesCount(path);

        if (count == 2) {   // 쌍 따움표가 한 경로에만 존재할 때
            int index = path.indexOf("\"");

            if (index == 0) {   // 쌍 따움표가 앞 경로에 존재할 때
                String[] paths = path.split("\" ");
                return new String[]{paths[0].replace("\"", ""), paths[1]};
            }

            // 쌍 따움표가 뒷 경로에 존재할 때
            String[] paths = path.split(" \"");
            return new String[]{paths[0], paths[1].replace("\"", "")};
        }

        if (count == 4) {   // 쌍 따움표가 두 경로 모두 존재할 때
            String[] paths = path.split("\" ");
            return new String[]{paths[0].replace("\"", ""), paths[1].replace("\"", "")};
        }

        return path.split(" ");
    }

    public Character whetherOverWrite(File file) {
        Scanner scanner = new Scanner(System.in);
        boolean whetherAnswer = false;

        while(!whetherAnswer) {
            System.out.print(file + Constants.WHETHER_OVER_WRITE);
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
