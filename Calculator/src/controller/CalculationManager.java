package controller;

import model.HistoryRepository;
import utility.Constants;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class CalculationManager {

    private HistoryRepository historyRepository;
    private String inputNumber;
    private String firstOperator;
    private String calculationState;
    private BigDecimal firstNumber;
    private boolean equalOperator;
    private boolean isSettingOperator;

    public CalculationManager() {
        this.historyRepository = new HistoryRepository();
        this.inputNumber = "0";
        this.firstOperator = "";
        this.calculationState = "";
        this.firstNumber = new BigDecimal(0);
        this.equalOperator = false;
        this.isSettingOperator = false;
    }

    public void processInputNumber(String number) {
        if (!this.firstOperator.isEmpty() && !isSettingOperator) {  // 연산자가 나온 직후 숫자가 들어왔을 때
            this.firstNumber = new BigDecimal(this.inputNumber);
            this.inputNumber = "0";
            isSettingOperator = true;
        }

        addInputNumber(number);
    }

    public void processOperator(String operator) {
        this.firstOperator = operator;
    }

    public void processC() {
        this.inputNumber = "0";
        this.firstOperator = "";
        this.calculationState = "";
        this.firstNumber = new BigDecimal(0);
        this.equalOperator = false;
        this.isSettingOperator = false;
    }

    public void processDelete() {
        if (isSettingOperator)  // 연산자가 나온 직후이면 return
            return;

        if (inputNumber.length() == 1) {    // 숫자가 1의자리 수일 떄
            this.inputNumber = "0";
            return;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < inputNumber.length() - 1; i++)  // 마지막 자릿 수만 제외
            result.append(inputNumber.charAt(i));

        this.inputNumber = processComma(result.toString());
    }

    public void processPoint(String point) {
        if (hasDecimalPoint(inputNumber))   // 이미 소수점이 있다면 return
            return;
        this.inputNumber += point;
    }

    public void processEqual(String operator) {
        if (this.firstOperator.isEmpty()) {   // 연산자가 비어있다면 연산자에 삽입
            this.firstOperator = operator;
            return;
        }

        // 연산자가 있는 상태에 '='이 들어온다면
        this.equalOperator = true;
        setCalculationState();
    }

    public String getCalculationState() {
        if (firstOperator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return "";
        else if (equalOperator)    // 연산자와 '='이 나왔다면
            return calculationState;
        return inputNumber + firstOperator;   // 첫번 째 연산자만 나왔을 때 숫자와 연산자 반환
    }

    public String getInputNumber() {
        return inputNumber;
    }

    public void deleteHistory() {
        this.historyRepository.clearHistoryList();
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

    private void setCalculationState() {
        BigDecimal secondNumber = new BigDecimal(inputNumber);

        switch (firstOperator) {
            case Constants.ADD_STRING:
                this.calculationState = firstNumber + firstOperator + secondNumber + Constants.EQUAL_STRING;
                this.inputNumber = firstNumber.add(secondNumber).toString();
                break;
            case Constants.SUBTRACT_STRING:
                this.calculationState = firstNumber + firstOperator + secondNumber + Constants.EQUAL_STRING;
                this.inputNumber = firstNumber.subtract(secondNumber).toString();
                break;
            case Constants.MULTIPLY_STRING:
                this.calculationState = firstNumber + firstOperator + secondNumber + Constants.EQUAL_STRING;
                this.inputNumber = firstNumber.multiply(secondNumber).toString();
                break;
            case Constants.DIVIDE_STRING:
                processDivide(secondNumber);
                break;
        }
    }

    private void processDivide(BigDecimal secondOperand) {

    }
}