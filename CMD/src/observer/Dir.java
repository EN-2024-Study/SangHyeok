package observer;

import controller.CommandExceptionManager;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;
import controller.FileManager;
import utility.StringManager;

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
        File pastFile = new File(cmd.getCurrentPath());

        if (command.length() < 4 || inputPath.isEmpty()) {
            printDir(pastFile);
            return;
        }

        File currentFile = fileManager.getFile(pastFile.toString(), inputPath);

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
            String lastModified = StringManager.getTimeInfo(f.lastModified());

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
        String lastModified = StringManager.getTimeInfo(file.lastModified());

        result.append(getDirectoryInfo(lastModified, "."));

        if (!file.getParentFile().toString().equals(Constants.ABSOLUTE_FRONT_STRING)) {
            lastModified = StringManager.getTimeInfo(file.getParentFile().lastModified());
            result.append("\n" + getDirectoryInfo(lastModified, ".."));
        }

        System.out.println(result);
    }

    private String getFileInfo(String lastModified, long fileByte, String name) {
        StringBuilder result = new StringBuilder(lastModified + "                  ");
        String byteString = StringManager.getCommaNumber(fileByte);

        result.append(StringManager.getBackspace(byteString.length()));
        return result + byteString + " " + name;
    }

    private String getDirectoryInfo(String lastModified, String name) {
        return lastModified + "    " + "<DIR>" + "          " + name;
    }

    private String getTotalFileInfo(int fileCount, long totalByte) {
        StringBuilder result = new StringBuilder("                ");
        String byteString = StringManager.getCommaNumber(totalByte);

        result.append(StringManager.getBackspace(String.valueOf(fileCount).length()));
        result.append(fileCount + "개 " + Constants.FILE + "                    ");

        result.append(StringManager.getBackspace(byteString.length()));
        result.append(byteString + " " + Constants.BYTE);
        return result.toString();
    }

    private String getTotalDirectoryInfo(int directoryCount) {
        StringBuilder result = new StringBuilder("                ");
        long totalByte = new File(Constants.ABSOLUTE_FRONT_STRING).getFreeSpace();
        String totalString = StringManager.getCommaNumber(totalByte);

        result.append(StringManager.getBackspace(String.valueOf(directoryCount).length()));
        result.append(directoryCount);
        result.append("개 " + Constants.DIRECTORY + "                 ");

        result.append(StringManager.getBackspace(totalString.length()));
        result.append(totalString + " " + Constants.BYTE + " 남음");
        return result.toString();
    }
}
