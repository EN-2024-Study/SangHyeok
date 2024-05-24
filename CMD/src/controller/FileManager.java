package controller;

import utility.Constants;

import java.io.File;
import java.io.IOException;

public class FileManager {

    public boolean isFileValid(File file) {
        return file.exists() && file.isDirectory();
    }

    public boolean isAbsolute(String command) {
        return command.contains(Constants.ABSOLUTE_FRONT_STRING);
    }

    public File getAbsoluteFile(String path) {
        try {
            return new File(path).getCanonicalFile();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public File getRelativeFile(String pastPath, String path) {
        String currentPath = pastPath.replace(">", "\\");
        currentPath += path;
        currentPath = currentPath.replace("\\", "/");

        return getAbsoluteFile(currentPath);
    }

    public String getOnePath(String command, int startIndex) {
        StringBuilder result = new StringBuilder();

        for (int i = startIndex; i < command.length(); i++) {    // 명령어 제거
            result.append(command.charAt(i));
        }

        return result.toString().trim().replace("\"", "");
    }

    public String[] getTwoPath(String command) {
        StringBuilder path1 = new StringBuilder();
        StringBuilder path2 = new StringBuilder();
        int endIndex = 0;

        while(isFileValid(new File(path1.toString()))) {

            for(int i = 5; i < command.length() - endIndex; i++) {
                path1.append(command.charAt(i));
            }

            path1 = new StringBuilder(path1.toString().replace(" ", ""));
            endIndex++;
        }

        for(int i = endIndex - 1; i < command.length(); i++) {
            path2.append(command.charAt(i));
        }

        if (isFileValid(new File(path2.toString()))) {  // 경로가 2개 존재한다면
            return new String[] {path1.toString(), path2.toString()};
        }

        if (isFileValid(new File(path1.toString()))) {  // 경로가 1개 존재한다면
            return new String[] {path1.toString()};
        }
        return null;    // 경로가 존재하지 않으면
    }
}
