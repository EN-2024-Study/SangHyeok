package observer;

import controller.*;
import interfaces.IObserver;
import observable.Cmd;
import utility.Constants;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

public class Copy extends OverWriteHandler implements IObserver {

    private FileProvider fileProvider;
    private CommandValidator commandValidator;

    public Copy(CommandValidator commandValidator, FileProvider fileProvider) {
        super();
        this.commandValidator = commandValidator;
        this.fileProvider = fileProvider;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (commandValidator.hasCopyValue(command) != Constants.ValidType.Valid) {
            return;
        }

        super.initAnswer();
        processCommand(cmd.getCurrentPath(), command);
    }

    // 경로를 알아낸 후 processCopy 수행하는 함수
    private void processCommand(String currentPath, String command) {
        File currentFile = new File(currentPath);
        String inputPath = StringFormatter.removeCommand(command, Constants.COMMANDS[2].length());

        // 명령어만 존재할 때
        if (command.length() < 5 || inputPath.isEmpty()) {
            System.out.println(Constants.WRONG_COMMAND_SYNTAX);
            return;
        }

        File[] files = fileProvider.getTwoPaths(currentPath, inputPath);

        if (files.length == 1) {
            processCopy(files[0], currentFile);
            return;
        }

        processCopy(files[0], files[1]);
    }

    private void processCopy(File sourceFile, File targetFile) {
        if (!sourceFile.exists()) {
            System.out.println(Constants.WRONG_FILE);
            return;
        }

        if (sourceFile.isDirectory()) {
            processDirectoryCopy(sourceFile, targetFile);
            return;
        }

        //============= sourceFile.exists() && sourceFile.isFile() =============//

        if (isFileCopyExecuted(sourceFile, targetFile, false))
            System.out.println("         " + 1 + Constants.VALID_COPY);
        else
            System.out.println("         " + 0 + Constants.VALID_COPY);
    }

    // sourceFile 이 Directory 일 때의 copy method
    private void processDirectoryCopy(File sourceDirectory, File targetFile) {
        File[] files = sourceDirectory.listFiles();
        int copyCount = 0;
        boolean existFile = false;

        for (File file : files) {
            if (file.isDirectory()) {
                continue;
            }

            // copy 수행
            existFile = true;
            System.out.println(file.getParentFile().getName() + "\\" + file.getName());
            if (isFileCopyExecuted(file, targetFile, true)) {
                copyCount++;
            }
        }

        if (!existFile) {   // sourceDirectory 안에 파일이 없을 때
            System.out.println(sourceDirectory.getName() + "\\*");
            System.out.println(Constants.WRONG_FILE);
            System.out.println("         " + 0 + Constants.VALID_COPY);
            return;
        }

        System.out.println("         " + copyCount + Constants.VALID_COPY);
    }

    // copy method 호출하는지에 대한 boolean method
    private boolean isFileCopyExecuted(File sourceFile, File targetFile, boolean isSourceDirectory) {
        if (targetFile.isDirectory()) {

            if (targetFile.getName().equals(sourceFile.getParentFile().getName())) {    // 같은 경로에 복사를 할 때
                System.out.println(Constants.WRONG_COPY);
                return false;
            }

            targetFile = new File(targetFile + "\\" + sourceFile.getName());
        }

        if (!targetFile.exists()) {
            copy(sourceFile, targetFile, isSourceDirectory);
            return true;
        }

        //===== target.exists() =====//

        if (super.isOverwriteConfirmed(targetFile.toString(), isSourceDirectory)) {
            copy(sourceFile, targetFile, isSourceDirectory);
            return true;
        }
        return false;
    }

    private void copy(File source, File target, boolean isSourceDirectory) {
        if (!isSourceDirectory) {
            try {
                Files.copy(source.toPath(), target.toPath(), StandardCopyOption.REPLACE_EXISTING);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            return;
        }

        try {
            InputStream inputStream = new FileInputStream(source);
            OutputStream outputStream = new FileOutputStream(target, true);

            int data;
            while ((data = inputStream.read()) != -1) {
                outputStream.write((char) data);
            }

            inputStream.close();
            outputStream.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}