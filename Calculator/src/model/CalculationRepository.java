package model;

import java.util.ArrayList;
import java.util.List;

public class CalculationRepository {

    private List<String> historyList;
    private List<Integer> numberList;
    private String operator;

    public CalculationRepository() {
        this.historyList = new ArrayList<>();
        this.numberList = new ArrayList<>();
        this.operator = "";
    }

    public boolean IsEmptyNumberList() {
        return this.numberList.isEmpty();
    }

    public boolean IsEmptyOperator() {
        return operator.equals("");
    }

    public void addNumber(int number) {
        this.numberList.add(number);

        for(Integer i : this.numberList)
            System.out.println(i);
        System.out.println("==================");
    }

    public Integer getLastNumber() {
        return this.numberList.get(this.numberList.size() - 1);
    }

    public String getOperator() {
        return this.operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }

    public void addHistory(String history) {
        this.historyList.add(history);
    }

    public void deleteHistory() {
        historyList = new ArrayList<>();
    }
}
