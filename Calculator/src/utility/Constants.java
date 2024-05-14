package utility;

import java.awt.*;

public class Constants {

    public final static Dimension FRAME_MINI_SIZE = new Dimension(400, 600);
    public final static String[] KEYPAD_STRINGS = new String[]{"÷", "CE", "C", "⌫", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "±", "0", ".", "="};
    public final static String[] NUMBER_STRINGS = new String[]{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
    public final static String DIVIDE_STRING = "÷";
    public final static String CE_STRING = "CE";
    public final static String C_STRING = "C";
    public final static String DELETE_STRING = "⌫";
    public final static String MULTIPLY_STRING = "×";
    public final static String SUBTRACT_STRING = "-";
    public final static String ADD_STRING = "+";
    public final static String SIGN_STRING = "±";
    public final static String POINT_STRING = ".";
    public final static String EQUAL_STRING = "=";
    public final static String TRASH_BUTTON = "\uD83D\uDDD1";
    public final static String HISTORY_BUTTON_PANEL = "HistoryButtonPanel";
    public final static String SMALL_NUMBER_PANEL = "SmallNumberPanel";
    public final static String BIG_NUMBER_PANEL = "BigNumberPanel";
    public final static String WRONG_DIVIDED1 = "정의되지 않은 결과입니다";
    public final static String WRONG_DIVIDED2 = "0으로 나눌 수 없습니다";
    public final static String OVERFLOW = "오버플로";
    public final static String[] OPERATORS = new String[]{Constants.ADD_STRING, Constants.SUBTRACT_STRING, Constants.MULTIPLY_STRING, Constants.DIVIDE_STRING, Constants.EQUAL_STRING};
    public final static int BIG_NUMBER_FONT_MAX_SIZE = 50;
    public final static int BIG_NUMBER_FONT_MIN_SIZE = 33;
    public final static int NUMBER_MAX_LENGTH = 16;
}
