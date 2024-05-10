package model;

import utility.Constants;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;

public class CalculationRepository {

    private List<String> historyList;
    private String inputNumber;
    private String firstOperator;
    private String secondOperator;

    public CalculationRepository() {
        this.historyList = new ArrayList<>();
        this.inputNumber = "0";
        this.firstOperator = "";
        this.secondOperator = "";
    }

    public void addDecimalPoint(String point) {
        if (hasDecimalPoint(inputNumber))
            return;
        this.inputNumber += point;
    }

    public void addInputNumber(String addNumber) {
        if (isMaxInputNumberList()) // 문자가 최대일 때 그냥 반환
            return;
        if (isFirstInput(addNumber))
            return;

        this.inputNumber += addNumber;
        this.inputNumber = processComma(inputNumber);   // 컴마 처리
    }

    private boolean isFirstInput(String addNumber) {
        if (inputNumber.equals("0")) {
            for (String n : Constants.NUMBER_STRINGS) {
                if (n.equals(addNumber)) {
                    this.inputNumber = addNumber;  // 첫 문자가 숫자라면 숫자 삽입
                    return true;
                }
            }
        }
        return false;
    }

    private String processComma(String str) {
        if (hasDecimalPoint(str))
            return str;

        String temp = str.replaceAll(",", "");
        BigDecimal bigDecimal = new BigDecimal(temp);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");

        return decimalFormat.format(bigDecimal);
    }

    public boolean isEmptyInputNumberList() {
        return this.inputNumber.equals("0");
    }

    private boolean isMaxInputNumberList() {
        if (hasDecimalPoint(inputNumber))
            return this.inputNumber.length() >= 22;
        return this.inputNumber.length() >= 21;
    }

    private boolean hasDecimalPoint(String str) {
        return str.contains(".");
    }

    public void clearInputNumberList() {
        this.inputNumber = "0";
    }

    public void deleteInputNumber() {
        if (inputNumber.length() == 1) {
            this.inputNumber = "0";
            return;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < inputNumber.length() - 1; i++)
            result.append(inputNumber.charAt(i));

        this.inputNumber = processComma(result.toString());
    }

    public void clearHistoryList() {
        this.historyList.clear();
    }

    public String getInputNumber() {
        return inputNumber;
    }
}
