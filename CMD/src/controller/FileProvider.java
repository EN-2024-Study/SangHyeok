package controller;

import utility.Constants;

import java.io.File;
import java.io.IOException;

public class FileProvider {

    private boolean isAbsolute(String command) {
        if (command.length() < 3) {
            return false;
        }

        String result = command.substring(0, 3);
        return result.equals(Constants.ABSOLUTE_FRONT_STRING);
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

    public File[] getTwoPaths(String pastPath, String path) {
        if (!path.contains(" ")) {
            File file = getFile(pastPath, path.replace("\"", ""));
            return new File[]{file};
        }

        int quotesCount = 0;
        boolean isTwo = false;
        StringBuilder frontPath = new StringBuilder();

        for (int i = 0; i < path.length(); i++) {
            char p = path.charAt(i);

            if (p == '\"') {
                quotesCount++;
            }

            // 따움표 사이의 공백이 아닌 공백을 만났을 때
            if (p == ' ' && quotesCount % 2 == 0) {
                isTwo = true;
                break;
            }

            frontPath.append(p);
        }

        if (!isTwo) {
            File file = getFile(pastPath, path.replace("\"", ""));
            return new File[]{file};
        }

        String backPath = path.substring(frontPath.length() + 1);
        File frontFile = getFile(pastPath, frontPath.toString().replace("\"", ""));
        File backFile = getFile(pastPath, backPath.replace("\"", ""));
        return new File[] {frontFile, backFile};
    }
}
