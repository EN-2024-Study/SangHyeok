package observer;

import controller.ExceptionManager;
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
    private ExceptionManager exceptionManager;

    public Dir(ExceptionManager exceptionManager, FileManager fileManager) {
        this.exceptionManager = exceptionManager;
        this.fileManager = fileManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!exceptionManager.isDirValid(command)) {
            return;
        }

        printVolume(cmd.getCurrentPath());
        processCommand(cmd, command);
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

    private void processCommand(Cmd cmd, String command) {
        File currentPath = new File(cmd.getCurrentPath().replace(">", ""));

        if (command.length() < 4 || command.charAt(3) == ' ') {
            printDir(currentPath);
            return;
        }

    }

    private void printDir(File path) {
        File[] fileList = path.listFiles();
        long totalByte = 0;
        int fileCount = 0;
        int directoryCount = 0;

        if (fileList == null) {
            System.out.println(Constants.NO_SEARCH_FILE);
            return;
        }

        for (File file : fileList) {
            if (file.isHidden())
                continue;

            String result;
            String lastModified = getTimeInfo(file.lastModified());

            if (file.isDirectory()) {
                directoryCount++;

                result = lastModified + "    " + "<DIR>" + "          " + file.getName();
            } else {
                totalByte += file.length();
                fileCount++;

                result = getFileInfo(lastModified, file.length(), file.getName());
            }

            System.out.println(result);
        }

        System.out.println(getTotalFileInfo(fileCount, totalByte));
        System.out.println(getTotalDirectoryInfo(directoryCount));
    }

    private String getFileInfo(String lastModified, long fileByte, String name) {
        StringBuilder result = new StringBuilder(lastModified + "                  ");
        String byteString = getCommaByte(fileByte);

        result.append(getBackspace(byteString));
        return result + byteString + " " + name;
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
        for(int i = 0; i < str.length(); i++) {
            result.append("\b");
        }
        return result.toString();
    }
}
