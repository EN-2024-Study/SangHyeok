package model;

import constant.Enums;
import constant.Queries;

import java.io.*;
import java.sql.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
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

    public List<String> getIdList() {
        List<String> resultList = new ArrayList<>();

        try {
            ResultSet resultSet = statement.executeQuery(Queries.SELECT_ID_QUERY);
            while(resultSet.next()) {
                resultList.add(resultSet.getString(1));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return resultList;
    }

    public HashMap<Enums.TextType, String> findAccount(String id) {
        HashMap<Enums.TextType, String> resultMap = new HashMap<>();

        try {
            ResultSet resultSet = statement.executeQuery(String.format(Queries.SELECT_WHERE_QUERY, id));
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

    public void insertAccount(String[] valueList) {
        String query = String.format(Queries.INSERT_QUERY, valueList[0], valueList[1],
                valueList[2], valueList[3], valueList[4], valueList[5], valueList[6], valueList[7], valueList[8]);
        processUpdateQuery(query);
    }

    public void deleteAccount(String id) {
        String query = String.format(Queries.DELETE_QUERY, id);
        processUpdateQuery(query);
    }

    private void processUpdateQuery(String query) {
        try {
            statement.executeUpdate(query);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}