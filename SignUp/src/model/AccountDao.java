package model;

import constant.Enums;
import constant.Queries;

import java.io.*;
import java.sql.*;
import java.util.HashMap;
import java.util.Map;

import static java.lang.System.getenv;

public class AccountDao {

    private Statement statement;

    public AccountDao() {
        try {
            this.statement = getConnection().createStatement();
        } catch (SQLException | IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    private Connection getConnection() throws SQLException, IOException, ClassNotFoundException {
        Map<String, String> environment = getenv();
        String url = environment.get("DB_URL");
        String userName = environment.get("DB_ID");
        String password = environment.get("DB_PASSWORD");
        return DriverManager.getConnection(url, userName, password);
    }

    public HashMap<Enums.TextType, String> findUser(String id) {
        HashMap<Enums.TextType, String> resultMap = new HashMap<>();

        try {
            ResultSet resultSet = statement.executeQuery(String.format(Queries.SELECT_QUERY, id));
            if (resultSet.next()) {
                resultMap.put(Enums.TextType.Name, resultSet.getString("name"));
                resultMap.put(Enums.TextType.Id, resultSet.getString("id"));
                resultMap.put(Enums.TextType.Password, resultSet.getString("password"));
                resultMap.put(Enums.TextType.BirthDay, resultSet.getString("birthday"));
                resultMap.put(Enums.TextType.Email, resultSet.getString("email"));
                resultMap.put(Enums.TextType.PhoneNumber, resultSet.getString("phone_number"));
                resultMap.put(Enums.TextType.Address, resultSet.getString("address"));
                resultMap.put(Enums.TextType.DetailedAddress, resultSet.getString("detailed_Address"));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return resultMap;
    }

    private void insertQuery(String[] valueList) {
        String query = String.format(Queries.INSERT_QUERY, valueList[0], valueList[1],
                valueList[2], valueList[3], valueList[4], valueList[5], valueList[6], valueList[7], valueList[8]);
        processQuery(query);
    }

    private void deleteQuery(String id) {
        String query = String.format(Queries.DELETE_QUERY, id);
        processQuery(query);
    }

    private void processQuery(String query) {
        try {
            statement.executeUpdate(query);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}