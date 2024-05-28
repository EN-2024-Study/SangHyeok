package constant;

public class Queries {
    public static final String SELECT_QUERY = "SELECT * FROM sign_up";
    public static final String SELECT_WHERE_QUERY = "SELECT * FROM sign_up WHERE id = '%s'";
    public static final String INSERT_QUERY = "INSERT INTO sign_up VALUES ('%s')";
    public static final String DELETE_QUERY = "DELETE FROM sign_up WHERE id = '%s'";
    public static final String FIELD_ID = "id";
    public static final String DB_PATH = "etc/환경변수.txt";
}
