package utility;

public class Constants {

    public final static String BUILD_STRING = "(c) Microsoft Corporation. All rights reserved.";
    public final static String ABSOLUTE_FRONT_STRING = "C:\\";
    public final static String CMD_EXE = "cmd.exe";
    public final static String CMD_EXE_EXIT = "/c";
    public final static String CMD_VERSION = "ver";
    public final static String CMD_VOLUME = "vol C:";
    public final static String DIRECTORY = "디렉터리";
    public final static String ENCODING_STRING = "MS949";
    public final static String HELP_PATH = "etc\\help.txt";
    public final static String INITIAL_ROUTE = ABSOLUTE_FRONT_STRING + "Users\\user>";
    public final static String WRONG_PATH = "지정된 경로를 찾을 수 없습니다.";
    public final static String WRONG_COMMAND = "은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n" + "배치 파일이 아닙니다.";
    public final static String[] COMMANDS = new String[] {"cd", "cls", "copy", "dir", "exit", "help", "move"};
    public final static Character[] VALID_ADDITION_COMMANDS = new Character[] {' ', '.', '&', '=', '\\'};
}
