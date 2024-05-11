package controller;

import model.HistoryRepository;
import utility.Constants;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Objects;

public class CalculationManager {

    private HistoryRepository historyRepository;
    private String outputNumber;
    private String firstOperator;
    private String calculationState;
    private BigDecimal firstNumber;
    private boolean isSettingOperator;

    public CalculationManager() {
        this.historyRepository = new HistoryRepository();
        this.outputNumber = "0";
        this.firstOperator = "";
        this.calculationState = "";
        this.firstNumber = new BigDecimal(0);
        this.isSettingOperator = false;
    }

    public void processInputNumber(String number) {
        if (!this.firstOperator.isEmpty() && !isSettingOperator) {  // 연산자가 나온 직후 숫자가 들어왔을 때
            this.firstNumber = new BigDecimal(this.outputNumber);
            this.outputNumber = "0";
            isSettingOperator = true;
        }

        addInputNumber(number);
    }

    public void processOperator(String operator) {
        this.firstOperator = operator;
        setCalculationState();
    }

    public void processC() {
        this.outputNumber = "0";
        this.firstOperator = "";
        this.calculationState = "";
        this.firstNumber = new BigDecimal(0);
        this.isSettingOperator = false;
    }

    public void processDelete() {
        if (isSettingOperator)  // 연산자가 나온 직후이면 return
            return;

        if (outputNumber.length() == 1) {    // 숫자가 1의자리 수일 떄
            this.outputNumber = "0";
            return;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < outputNumber.length() - 1; i++)  // 마지막 자릿 수만 제외
            result.append(outputNumber.charAt(i));

        this.outputNumber = processComma(result.toString());
    }

    public void processPoint(String point) {
        if (hasDecimalPoint(outputNumber))   // 이미 소수점이 있다면 return
            return;
        this.outputNumber += point;
    }

    public void processEqual(String operator) {
        if (this.firstOperator.isEmpty()) {   // 연산자가 비어있다면 연산자에 삽입
            this.firstOperator = operator;
            return;
        }

        setCalculationState();
    }

    public String getCalculationState() {
        if (firstOperator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return "";
        return calculationState;
    }

    public String getOutputNumber() {
        return outputNumber;
    }

    public void deleteHistory() {
        this.historyRepository.clearHistoryList();
    }

    private void addInputNumber(String addNumber) {
        if (isMaxInputNumberList()) // 문자가 최대일 때 그냥 반환
            return;
        if (isFirstInput(addNumber))
            return;

        this.outputNumber += addNumber;
        this.outputNumber = processComma(outputNumber);   // 컴마 처리
    }

    private boolean isMaxInputNumberList() {
        if (hasDecimalPoint(outputNumber))
            return this.outputNumber.length() >= 22;
        return this.outputNumber.length() >= 21;
    }

    private boolean isFirstInput(String addNumber) {
        if (outputNumber.equals("0")) {
            if (addNumber.equals("0")) // 첫 숫자가 0이라면 저장하지 않고 종료
                return true;

            for (String n : Constants.NUMBER_STRINGS) {
                if (n.equals(addNumber)) {
                    this.outputNumber = addNumber;  // 첫 문자가 숫자라면 숫자 삽입
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
        if (Objects.equals(firstNumber, new BigDecimal("0"))) {  // 연산자 한개만 나온 상태일 때
            this.firstNumber = new BigDecimal(this.outputNumber);
            this.calculationState = this.firstNumber + this.firstOperator;
            return;
        }

        BigDecimal secondNumber = new BigDecimal(outputNumber);
        this.calculationState = this.firstNumber + this.firstOperator + secondNumber + Constants.EQUAL_STRING;

        switch (firstOperator) {
            case Constants.ADD_STRING:
                this.outputNumber = this.firstNumber.add(secondNumber).toString();
                break;
            case Constants.SUBTRACT_STRING:
                this.outputNumber = this.firstNumber.subtract(secondNumber).toString();
                break;
            case Constants.MULTIPLY_STRING:
                this.outputNumber = this.firstNumber.multiply(secondNumber).toString();
                break;
            case Constants.DIVIDE_STRING:
                processDivide(secondNumber);
                break;
        }
    }

    private void processDivide(BigDecimal secondNumber) {
        if (secondNumber.equals("0")) {
            this.calculationState = "";

            if (this.firstNumber.equals("0"))
                this.outputNumber = "정의되지 않은 결과입니다.";
            else
                this.outputNumber = "0으로 나눌 수 없습니다.";
            return;
        }

        this.outputNumber = this.firstNumber.divide(secondNumber).toString();
    }
}