package model;

import constant.Queries;

import java.io.*;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class AccountDao {

    private Statement statement;

    public AccountDao() throws SQLException, IOException {
        this.statement = getConnection().createStatement();
    }

    private Connection getConnection() throws SQLException, IOException {
        BufferedReader bufferedReader = new BufferedReader(new FileReader(Queries.DB_PATH));
        String url = bufferedReader.readLine();
        String username = bufferedReader.readLine();
        String password = bufferedReader.readLine();
        return DriverManager.getConnection(url, username, password);
    }

    private void setQuery(String query) throws SQLException {
        statement.executeUpdate(query);
    }

    private String selectQuery(String key) throws SQLException {
        ResultSet resultSet = statement.executeQuery(Queries.SELECT_QUERY);
        String resultString = "";
        while (resultSet.next()) {
            resultString = resultSet.getString(key);
        }
        return resultString;
    }

    private List<String> selectAllQuery() throws SQLException {
        ResultSet resultSet = statement.executeQuery(Queries.SELECT_QUERY);
        List<String> resultStrings = new ArrayList<>();
        while (resultSet.next()) {
            resultStrings.add(resultSet.getString(Queries.FIELD_ID));
        }
        return resultStrings;
    }
}