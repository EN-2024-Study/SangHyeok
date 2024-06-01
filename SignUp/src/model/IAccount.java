package model;

import constant.Enums;

import java.util.HashMap;
import java.util.List;

public interface IAccount {
    List<String> getIdList();
    HashMap<Enums.TextType, String> findAccount(String id);
    void insertAccount(HashMap<Enums.TextType, String> account);
    void modifyAccount(String id, String column, String value);
    void deleteAccount(String id);
}
