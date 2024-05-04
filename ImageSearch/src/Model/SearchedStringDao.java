package Model;

import Utility.Constants;

import java.sql.SQLException;
import java.util.List;

public class SearchedStringDao {

    private DBConnector dbConnector;

    public SearchedStringDao() throws SQLException {
        this.dbConnector = DBConnector.getInstance();
    }

    public void insert(String s) throws SQLException {
        List<String> searchStrings = dbConnector.selectAllQuery();
        for (String item : searchStrings)
            if (item.equals(s))
                delete(s);

        String query = String.format(Constants.INSERT_QUERY, s);
        dbConnector.setQuery(query);
    }

    public void delete(String s) throws SQLException {
        String query = String.format(Constants.DELETE_QUERY, s);
        dbConnector.setQuery(query);
    }

    public String select(String s) throws SQLException {
        String query = String.format(Constants.SELECT_WHERE_QUERY, s);
        return dbConnector.selectQuery(query);
    }

    public List<String> selectAll() throws SQLException {
        return dbConnector.selectAllQuery();
    }
}
