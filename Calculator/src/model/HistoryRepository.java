package model;

import java.util.ArrayList;
import java.util.List;

public class HistoryRepository {

    private List<String> historyList;

    public HistoryRepository() {
        this.historyList = new ArrayList<>();
    }

    public void clearHistoryList() {
        this.historyList.clear();
    }
}