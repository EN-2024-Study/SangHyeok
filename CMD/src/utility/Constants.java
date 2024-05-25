package utility;

public class Constants {

    public final static String BUILD_STRING = "(c) Microsoft Corporation. All rights reserved.";
    public final static String ABSOLUTE_FRONT_STRING = "C:\\";
    public final static String CMD_EXE = "cmd.exe";
    public final static String CMD_EXE_EXIT = "/c";
    public final static String CMD_VERSION = "ver";
    public final static String CMD_VOLUME = "vol C:";
    public final static String DIRECTORY = "디렉터리";
    public final static String FILE = "파일";
    public final static String BYTE = "바이트";
    public final static String ENCODING_STRING = "MS949";
    public final static String HELP_PATH = "etc\\help.txt";
    public final static String INITIAL_PATH = "user.home";
    public final static String WRONG_PATH = "지정된 경로를 찾을 수 없습니다.";
    public final static String WRONG_FILE = "지정된 파일를 찾을 수 없습니다.";
    public final static String WRONG_COMMAND = "은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n" + "배치 파일이 아닙니다.";
    public final static String WRONG_COMMAND_SYNTAX = "명령 구문이 올바르지 않습니다.";
    public final static String WRONG_COPY = "같은 파일로 복사할 수 없습니다.";
    public final static String WRONG_ACCESS = "액세스가 거부되었습니다.";
    public final static String VALID_COPY = "개 파일이 복사되었습니다.";
    public final static String VALID_FILE_MOVE = "개 파일을 이동했습니다.";
    public final static String VALID_DIRECTORY_MOVE = "개 디렉터리를 이동했습니다.";
    public final static String NO_SEARCH_FILE = "파일을 찾을 수 없습니다.";
    public final static String WHETHER_OVER_WRITE = "을(를) 덮어쓰시겠습니까? (Yes/No/All):";
    public final static String[] COMMANDS = new String[] {"cd", "cls", "copy", "dir", "exit", "help", "move"};
    public final static Character[] INVALID_ADDITION_COMMANDS = new Character[] {'|', '&', '*', '?', '<', '>'};
    public enum ValidType {
        Valid, WrongCommand, WrongCommandSyntax, WrongSwitch
    }
}
