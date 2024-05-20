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
        // 루트 디렉토리를 File 객체로 만듭니다
        File rootDir = new File("C:\\");

        // 루트 디렉토리가 존재하고 디렉토리인지 확인합니다
        if (rootDir.exists() && rootDir.isDirectory()) {
            // 루트 디렉토리 안의 파일과 디렉토리를 목록으로 가져옵니다
            File[] filesList = rootDir.listFiles();
            // 날짜 형식을 지정합니다
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm");

            if (filesList != null) {
                // 파일과 디렉토리 정보를 출력합니다
                for (File file : filesList) {
                    String lastModified = sdf.format(new Date(file.lastModified()));
                    if (file.isDirectory()) {
                        System.out.println("[DIR] " + lastModified + " " + file.getName());
                    } else {
                        System.out.println("[FILE] " + lastModified + " " + file.getName());
                    }
                }
            } else {
                System.out.println("루트 디렉토리를 읽을 수 없습니다.");
            }
        } else {
            System.out.println("루트 디렉토리가 존재하지 않거나 디렉토리가 아닙니다.");
        }
    }
}
