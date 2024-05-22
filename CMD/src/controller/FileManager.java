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

    public String getPath(String command, int startIndex) {
        StringBuilder result = new StringBuilder();
        command = command.replace(" ", "");

        for (int i = startIndex; i < command.length(); i++) {    // 명령어 제거
            result.append(command.charAt(i));
        }

        return result.toString();
    }
}
