package constant;

public class Queries {
    public static final String SELECT_ID_QUERY = "SELECT id FROM account";
    public static final String SELECT_WHERE_QUERY = "SELECT * FROM account WHERE id = '%s'";
    public static final String INSERT_QUERY = "INSERT INTO account VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')";
    public static final String DELETE_QUERY = "DELETE FROM account WHERE id = '%s'";
    public static final String UPDATE_QUERY = "UPDATE account SET %s = '%s' WHERE id = '%s'";

}
