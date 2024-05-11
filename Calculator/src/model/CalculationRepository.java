package model;

import utility.Constants;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;

public class CalculationRepository {

    private List<String> historyList;
    private String inputNumber;
    private BigDecimal firstOperand;
    private String firstOperator;
    private boolean equal;
    private String calculationState;

    public CalculationRepository() {
        this.historyList = new ArrayList<>();
        this.inputNumber = "0";
        this.firstOperand = new BigDecimal(0);
        this.firstOperator = "";
        this.equal = false;
        this.calculationState = "";
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
            if (addNumber.equals("0")) // 첫 숫자가 0이라면 저장하지 않고 종료
                return true;

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

    private boolean isMaxInputNumberList() {
        if (hasDecimalPoint(inputNumber))
            return this.inputNumber.length() >= 22;
        return this.inputNumber.length() >= 21;
    }

    private boolean hasDecimalPoint(String str) {
        return str.contains(".");
    }

    public void clearInputNumber() {
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

    public String getFirstOperator() {
        return firstOperator;
    }

    public BigDecimal getFirstOperand() {
        return firstOperand;
    }

    public void setFirstOperator(String operator) {
        this.firstOperator = operator;
    }

    public void setFirstOperand() {
        this.firstOperand = new BigDecimal(inputNumber);
        this.inputNumber = "0";
    }

    public boolean hasEqual() {
        return equal;
    }

    public void setEqual(boolean equal) {
        this.equal = equal;
    }

    public void setCalculationState() {
        BigDecimal secondOperand = new BigDecimal(inputNumber);

        switch (firstOperator) {
            case Constants.ADD_STRING:
                calculationState = firstOperand.add(secondOperand).toString();
                break;
            case Constants.SUBTRACT_STRING:
                calculationState = firstOperand.subtract(secondOperand).toString();
                break;
            case Constants.MULTIPLY_STRING:
                calculationState = firstOperand.multiply(secondOperand).toString();
                break;
            case Constants.DIVIDE_STRING:
                processDivide(secondOperand);
                break;
        }
    }

    private void processDivide(BigDecimal secondOperand) {

    }

    public String getCalculationState() {
        return calculationState;
    }
}
