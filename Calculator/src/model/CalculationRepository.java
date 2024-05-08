package model;

import java.util.ArrayList;
import java.util.List;

public class CalculationRepository {

    private List<String> historyList;
    private List<Integer> inputNumberList;
    private String firstOperator;
    private String secondOperator;

    public CalculationRepository() {
        this.historyList = new ArrayList<>();
        this.inputNumberList = new ArrayList<>();
        this.firstOperator = "";
        this.secondOperator = "";
    }

    public void addNumber(int number) {
        this.inputNumberList.add(number);
    }

    public void setFirstOperator(String firstOperator) {
        this.firstOperator = firstOperator;
    }

    public void setSecondOperator(String secondOperator) {
        this.secondOperator = secondOperator;
    }

    public boolean isEmptyFirstOperator() {
        return this.firstOperator.isEmpty();
    }

    public boolean isEmptySecondOperator() {
        return this.secondOperator.isEmpty();
    }

    public void deleteHistory() {
        historyList = new ArrayList<>();
    }
}
