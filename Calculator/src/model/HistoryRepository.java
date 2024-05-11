package model;

import java.util.ArrayList;
import java.util.List;

public class HistoryRepository {

    List<String> historyList;

    public HistoryRepository() {
        historyList = new ArrayList<>();
    }

    public void clearHistoryList() {
        this.historyList.clear();
    }
}