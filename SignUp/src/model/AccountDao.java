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
        ResultSet resultSet = getResultSet(Queries.SELECT_ID_QUERY);

        try {
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
        ResultSet resultSet = getResultSet(String.format(Queries.SELECT_WHERE_QUERY, id));

        try {
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

    public void insertAccount(HashMap<Enums.TextType, String> account) {
        String name = account.get(Enums.TextType.Name);
        String id = account.get(Enums.TextType.Id);
        String password = account.get(Enums.TextType.Password);
        String birthday = account.get(Enums.TextType.BirthDay);
        String email = account.get(Enums.TextType.Email);
        String phoneNumber = account.get(Enums.TextType.PhoneNumber);
        String address = account.get(Enums.TextType.Address);
        String detailedAddress = account.get(Enums.TextType.DetailedAddress);
        String query = String.format(Queries.INSERT_QUERY, name, id,
                password, birthday, email, phoneNumber, address, detailedAddress);

        processUpdateQuery(query);
    }

    public void deleteAccount(String id) {
        String query = String.format(Queries.DELETE_QUERY, id);
        processUpdateQuery(query);
    }

    private ResultSet getResultSet(String query) {
        try {
            return statement.executeQuery(query);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    private void processUpdateQuery(String query) {
        try {
            statement.executeUpdate(query);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}