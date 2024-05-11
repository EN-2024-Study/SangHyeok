package controller;

import model.HistoryRepository;
import utility.Constants;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class CalculationManager {

    private HistoryRepository historyRepository;
    private String inputNumber;
    private BigDecimal firstNumber;
    private String firstOperator;
    private boolean equalOperator;
    private String calculationState;
    private boolean isSettingFirstOperand;

    public CalculationManager() {
        this.historyRepository = new HistoryRepository();
        this.inputNumber = "0";
        this.firstNumber = new BigDecimal(0);
        this.firstOperator = "";
        this.equalOperator = false;
        this.calculationState = "";
        this.isSettingFirstOperand = false;
    }

    public void processInputNumber(String number) {
        if (firstOperator.isEmpty() ||
                isSettingFirstOperand) {    // 연산자가 나오지 않았거나 이미 첫번째 연산자가 나왔을 때
            addInputNumber(number);   // 숫자 삽입
            return;
        }

        this.firstNumber = new BigDecimal(inputNumber);
        this.inputNumber = "0";    // 연산자가 나오고 나서 처음 숫자 입력을 받을 때
        addInputNumber(number);
        isSettingFirstOperand = true;
    }

    private void addInputNumber(String addNumber) {
        if (isMaxInputNumberList()) // 문자가 최대일 때 그냥 반환
            return;
        if (isFirstInput(addNumber))
            return;

        this.inputNumber += addNumber;
        this.inputNumber = processComma(inputNumber);   // 컴마 처리
    }

    private boolean isMaxInputNumberList() {
        if (hasDecimalPoint(inputNumber))
            return this.inputNumber.length() >= 22;
        return this.inputNumber.length() >= 21;
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


    private boolean hasDecimalPoint(String str) {
        return str.contains(".");
    }

    public void processOperator(String operator) {
        firstOperator = operator;
    }

    public void processC() {
        inputNumber = "0";
        firstOperator = "";
        isSettingFirstOperand = false;
    }

    public void processDelete() {
        if (inputNumber.length() == 1) {
            this.inputNumber = "0";
            return;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < inputNumber.length() - 1; i++)
            result.append(inputNumber.charAt(i));

        this.inputNumber = processComma(result.toString());
    }

    public void processPoint(String point) {
        if (hasDecimalPoint(inputNumber))
            return;
        this.inputNumber += point;
    }

    public void processEqual(String operator) {
        if (this.firstOperator.isEmpty()) {   // 첫번 째 연산자가 '='일 때
            firstOperator = operator;
            return;
        }

        equalOperator = true;   // 두번 째 연산자가 '='일 때
        setCalculationState();
        isSettingFirstOperand = false;
    }

    public String getCalculationState() {

        if (firstOperator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return "";
        else if (equalOperator)    // 연산자와 '='이 나왔다면
            return getCalculationState();
        return firstNumber.toString() + firstOperator;   // 첫번 째 연산자만 나왔을 때 숫자와 연산자 반환
    }

    private void setCalculationState() {
        BigDecimal secondOperand = new BigDecimal(inputNumber);

        switch (firstOperator) {
            case Constants.ADD_STRING:
                calculationState = firstNumber.add(secondOperand).toString();
                break;
            case Constants.SUBTRACT_STRING:
                calculationState = firstNumber.subtract(secondOperand).toString();
                break;
            case Constants.MULTIPLY_STRING:
                calculationState = firstNumber.multiply(secondOperand).toString();
                break;
            case Constants.DIVIDE_STRING:
                processDivide(secondOperand);
                break;
        }
    }

    private void processDivide(BigDecimal secondOperand) {

    }

    public String getInputNumber() {
        return inputNumber;
    }

    public void deleteHistory() {
        historyRepository.clearHistoryList();
    }
}
