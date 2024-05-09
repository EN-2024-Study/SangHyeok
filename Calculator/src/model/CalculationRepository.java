package model;

import java.util.ArrayList;
import java.util.List;

public class CalculationRepository {

    private List<String> historyList;
    private List<Character> inputNumberList;
    private String firstOperator;
    private String secondOperator;

    public CalculationRepository() {
        this.historyList = new ArrayList<>();
        this.inputNumberList = new ArrayList<>();
        this.firstOperator = "";
        this.secondOperator = "";
    }

    public void addInputNumber(Character number) {
        this.inputNumberList.add(number);
    }

    public boolean isEmptyInputNumberList() {
        return this.inputNumberList.isEmpty();
    }

    public boolean isMaxInputNumberList() {
        return this.inputNumberList.size() >= 16;
    }

    public boolean hasDecimalPoint() {
        for(Character number : this.inputNumberList)
            if(number.equals('.'))
                return true;
        return false;
    }

    public void clearInputNumberList() {
        this.inputNumberList.clear();
    }

    public void deleteInputNumber() {
        this.inputNumberList.remove(this.inputNumberList.size() - 1);
    }

    public boolean isEmptyFirstOperator() {
        return this.firstOperator.isEmpty();
    }

    public boolean isEmptySecondOperator() {
        return this.secondOperator.isEmpty();
    }

    public void setFirstOperator(String firstOperator) {
        this.firstOperator = firstOperator;
    }

    public void setSecondOperator(String secondOperator) {
        this.secondOperator = secondOperator;
    }

    public void clearHistoryList() {
        this.historyList.clear();
    }
}
