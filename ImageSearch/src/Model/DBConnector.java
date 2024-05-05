package Model;

import Utility.Constants;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class DBConnector {
    private static DBConnector instance;
    private Statement statement;

    private DBConnector() throws SQLException {
        Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/image_search", "root", "tkdgur0908");
        this.statement = connection.createStatement();
    }

    public static DBConnector getInstance() throws SQLException {
        if (instance == null) {
            instance = new DBConnector();
        }
        return instance;
    }

    public void setQuery(String query) throws SQLException {
        statement.executeUpdate(query);
    }

    public String selectQuery(String key) throws SQLException {
        ResultSet resultSet = statement.executeQuery(Constants.SELECT_QUERY);
        String resultString = "";
        while (resultSet.next()) {
            resultString = resultSet.getString(key);
        }
        return resultString;
    }

    public List<String> selectAllQuery() throws SQLException {
        ResultSet resultSet = statement.executeQuery(Constants.SELECT_QUERY);
        List<String> resultStrings = new ArrayList<>();
        while (resultSet.next()) {
            resultStrings.add(resultSet.getString(Constants.FIELD_SEARCHED_STRING));
        }
        return resultStrings;
    }
}
