package observer;

import interfaces.IObserver;
import observable.CmdManager;
import utility.Constants;
import controller.PathManager;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Dir implements IObserver {

    private PathManager pathManager;

    public Dir(PathManager pathManager) {
        this.pathManager = pathManager;
    }

    @Override
    public void update(CmdManager cmdManager, String command) {
        if (!isCommandValid(command))
            return;

        printVolume(cmdManager.getCurrentPath());

    }

    private boolean isCommandValid(String command) {
        if (command.length() < 3 || !Constants.COMMANDS[3].equals(command.charAt(0) + "" + command.charAt(1) + command.charAt(2)))
            return false;

        if (command.length() > 3) {
            for(Character c : Constants.VALID_ADDITION_COMMANDS) {
                if (c == command.charAt(3))
                    return true;
            }
            return false;
        }
        return true;
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

    private void test1() {
        File rootDirectory = new File("C:\\");

        // 루트 디렉토리가 존재하고 디렉토리인지 확인
        if (!rootDirectory.exists() || !rootDirectory.isDirectory()) {
            System.out.println("루트 디렉토리가 존재하지 않거나 디렉토리가 아닙니다.");
            return;
        }

        File[] fileList = rootDirectory.listFiles();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm");

        if (fileList == null) {
            System.out.println("루트 디렉토리를 읽을 수 없습니다.");
            return;
        }

        for (File file : fileList) {
            String lastModified = sdf.format(new Date(file.lastModified()));
            if (file.isDirectory()) {
                System.out.println("[DIR] " + lastModified + " " + file.getName());
            } else {
                System.out.println("[FILE] " + lastModified + " " + file.getName());
            }
        }
    }
}
