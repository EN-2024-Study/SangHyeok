package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;
import controller.FileManager;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Dir implements IObserver {

    private FileManager fileManager;
    private CommandExceptionManager commandExceptionManager;

    public Dir(CommandExceptionManager commandExceptionManager, FileManager fileManager) {
        this.commandExceptionManager = commandExceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!commandExceptionManager.isDirValid(command)) {
            return;
        }

        printVolume(cmd.getCurrentPath());
        processCommand(cmd, command);
    }

    private void processCommand(Cmd cmd, String command) {
        String inputPath = fileManager.removeCommand(command, Constants.COMMANDS[3].length());
        File currentFile = new File(cmd.getCurrentPath().replace(">", ""));

        if (command.length() < 4 || inputPath.isEmpty()) {
            printDir(currentFile);
            return;
        }

        if (fileManager.isAbsolute(inputPath)) {
            currentFile = fileManager.getAbsoluteFile(inputPath);
        } else {
            currentFile = fileManager.getRelativeFile(currentFile + ">", inputPath);
        }

        if (!currentFile.isDirectory()) {
            System.out.println(Constants.NO_SEARCH_FILE);
            return;
        }

        printDir(currentFile);
    }

    private void printVolume(String path) {
        ProcessBuilder processBuilder = new ProcessBuilder(Constants.CMD_EXE, Constants.CMD_EXE_EXIT, Constants.CMD_VOLUME);

        try {
            Process process = processBuilder.start();
            BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream(), Constants.ENCODING_STRING));
            System.out.println(reader.readLine());
            System.out.println(reader.readLine());

            process.waitFor();
        } catch (IOException | InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println();
        System.out.println(path.replace(">", "") + " " + Constants.DIRECTORY);
        System.out.println();
    }

    private void printDir(File file) {
        File[] fileList = file.listFiles();
        long totalByte = 0;
        int fileCount = 0, directoryCount = 0;

        if (fileList == null) {
            System.out.println(Constants.NO_SEARCH_FILE);
            return;
        }

        if (!file.getName().isEmpty()) {    // 최상위 path 가 아닐 때
            printCurrentDir(file);
        }

        for (File f : fileList) {
            if (f.isHidden())
                continue;

            String result;
            String lastModified = getTimeInfo(f.lastModified());

            if (f.isDirectory()) {  // DIC 일 때
                directoryCount++;

                result = getDirectoryInfo(lastModified, f.getName());
            } else {    // FILE 일 때
                totalByte += f.length();
                fileCount++;

                result = getFileInfo(lastModified, f.length(), f.getName());
            }

            System.out.println(result);
        }

        System.out.println(getTotalFileInfo(fileCount, totalByte)); // FILE 출력
        System.out.println(getTotalDirectoryInfo(directoryCount));  // DIC 와 C 드라이브 남은 용량 출력
    }

    private void printCurrentDir(File file) {
        StringBuilder result = new StringBuilder();
        String lastModified = getTimeInfo(file.lastModified());

        result.append(getDirectoryInfo(lastModified, "."));

        if (!file.getParentFile().toString().equals(Constants.ABSOLUTE_FRONT_STRING)) {
            lastModified = getTimeInfo(file.getParentFile().lastModified());
            result.append("\n" + getDirectoryInfo(lastModified, ".."));
        }

        System.out.println(result);
    }

    private String getFileInfo(String lastModified, long fileByte, String name) {
        StringBuilder result = new StringBuilder(lastModified + "                  ");
        String byteString = getCommaByte(fileByte);

        result.append(getBackspace(byteString));
        return result + byteString + " " + name;
    }

    private String getDirectoryInfo(String lastModified, String name) {
        return lastModified + "    " + "<DIR>" + "          " + name;
    }

    private String getTotalFileInfo(int fileCount, long totalByte) {
        StringBuilder result = new StringBuilder("                ");
        String byteString = getCommaByte(totalByte);

        result.append(getBackspace(String.valueOf(fileCount)));
        result.append(fileCount + "개 " + Constants.FILE + "                    ");

        result.append(getBackspace(byteString));
        result.append(byteString + " " + Constants.BYTE);
        return result.toString();
    }

    private String getTotalDirectoryInfo(int directoryCount) {
        StringBuilder result = new StringBuilder("                ");
        long totalByte = new File(Constants.ABSOLUTE_FRONT_STRING).getFreeSpace();
        String totalString = getCommaByte(totalByte);

        result.append(getBackspace(String.valueOf(directoryCount)));
        result.append(directoryCount);
        result.append("개 " + Constants.DIRECTORY + "                 ");

        result.append(getBackspace(totalString));
        result.append(totalString + " " + Constants.BYTE + " 남음");
        return result.toString();
    }

    private String getTimeInfo(long time) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd a hh:mm");
        return dateFormat.format(new Date(time));
    }

    private String getCommaByte(long number) {
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        return decimalFormat.format(number);
    }

    private String getBackspace(String str) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < str.length(); i++) {
            result.append("\b");
        }
        return result.toString();
    }
}
