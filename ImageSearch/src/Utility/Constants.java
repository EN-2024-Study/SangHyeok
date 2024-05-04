package Utility;

public class Constants {
    public static final String TITLE = "Search Image";
    public static final String BUTTON_SEARCH = "검색";
    public static final String BUTTON_HISTORY = "기록 조회";
    public static final String BUTTTON_GOBACK = "뒤로 가기";
    public static final String BUTTTON_DELETE = "기록 삭제";
    public static final String ERROR_MESSAGE = "잘못된 입력입니다.";
    public static final String SELECT_QUERY = "SELECT * FROM searched";
    public static final String SELECT_WHERE_QUERY = "SELECT * FROM searched WHERE searched_string = '%s'";
    public static final String INSERT_QUERY = "INSERT INTO searched VALUES ('%s')";
    public static final String DELETE_QUERY = "DELETE FROM searched WHERE searched_string = '%s'";
    public static final String FIELD_SEARCHED_STRING = "searched_string";
    public static final Object[] COMBO_BOX = new Object[] {10, 20, 30};
}
