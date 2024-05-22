package controller;

import utility.Constants;

import java.io.File;
import java.io.IOException;

public class PathManager {

    public boolean isPathValid(File path) {
        return path.exists() && path.isDirectory();
    }

    public boolean isAbsolute(String command) {
        return command.contains(Constants.ABSOLUTE_FRONT_STRING);
    }

    public File getRelativeFile(String pastPath, String path) {
        String currentPath = pastPath.replace(">", "\\");
        currentPath += path;
        currentPath = currentPath.replace("\\", "/");

        try {
            return new File(currentPath).getCanonicalFile();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
