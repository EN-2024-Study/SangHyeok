package observer;

import interfaces.IObserver;
import observable.CmdManager;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Dir implements IObserver {
    @Override
    public void update(CmdManager o, String arg) {

    }

    private void test() {
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
