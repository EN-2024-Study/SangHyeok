package model;

import java.util.ArrayList;
import java.util.List;

public class CalculationRepository {

    private List<Integer> numberList;
    private String operator;

    public CalculationRepository() {
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
}
