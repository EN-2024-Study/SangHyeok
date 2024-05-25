package controller;

public class OverWriteManager {

    private FileManager fileManager;
    private Character answer;

    public OverWriteManager(FileManager fileManager) {
        this.fileManager = fileManager;
        initAnswer();
    }

    protected void initAnswer() {
        this.answer = 'n';
    }

    protected boolean isProcessOverWrite(String targetPath) {
        // 기존 파일에 덮어씌울 때
        if (answer != 'a') {
            answer = fileManager.whetherOverWrite(targetPath);
        }

        return switch (answer) {
            case 'y', 'a' -> true;
            default -> false;
        };
    }
}
