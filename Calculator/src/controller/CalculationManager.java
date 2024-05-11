package controller;

import model.HistoryRepository;
import utility.Constants;
import java.math.BigDecimal;
import java.util.Objects;

public class CalculationManager {

    private enum LastInputType {
        InitialValue, Number, Equal, Operator
    }
    private HistoryRepository historyRepository;
    private String outputNumber;
    private String firstOperator;
    private String calculationState;
    private BigDecimal firstNumber;
    private LastInputType lastInputType;

    public CalculationManager() {
        this.historyRepository = new HistoryRepository();
        this.outputNumber = "0";
        this.firstOperator = "";
        this.calculationState = " ";
        this.firstNumber = new BigDecimal(0);
        this.lastInputType = LastInputType.InitialValue;
    }

    public void processInputNumber(String number) {
        if (this.lastInputType == LastInputType.Operator ||
        this.lastInputType == LastInputType.Equal) {  // 연산자가 나온 직후 숫자가 들어왔을 때
            this.firstNumber = new BigDecimal(this.outputNumber);
            this.outputNumber = "0";
        }

        addInputNumber(number);
        this.lastInputType = LastInputType.Number;
    }

    public void processOperator(String operator) {
        this.firstOperator = operator;
        this.lastInputType = LastInputType.Operator;
        setCalculationState();
        this.outputNumber = this.firstNumber.toString();    // 마지막 입력이 소수점이였을 때 연산자가 들어올 수 있으므로
    }

    public void processC() {
        this.outputNumber = "0";
        this.firstOperator = "";
        this.calculationState = " ";
        this.firstNumber = new BigDecimal("0");
    }

    public void processDelete() {
        if (this.lastInputType == LastInputType.Operator)  // 연산자가 나온 직후이면 return
            return;
        else if (this.lastInputType == LastInputType.Equal) {
            this.calculationState = " ";    
            return;
        }

        if (outputNumber.length() == 1) {    // 숫자가 1의자리 수일 떄
            this.outputNumber = "0";
            return;
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < outputNumber.length() - 1; i++)  // 마지막 자릿 수만 삭제
            result.append(outputNumber.charAt(i));

        this.outputNumber = result.toString();
    }

    public void processPoint(String point) {
        if (this.outputNumber.contains(Constants.POINT_STRING))   // 이미 소수점이 있다면 return
            return;
        if (this.lastInputType == LastInputType.Operator) { // 마지막 입력이 연산자였다면 "0."으로 삽입
            this.outputNumber = "0" + point;
            this.lastInputType = LastInputType.Number;
            return;
        }

        this.lastInputType = LastInputType.Number;
        this.outputNumber += point;
    }

    public void processEqual(String operator) {
        if (this.firstOperator.isEmpty()) {   // 연산자가 비어있다면 연산자에 삽입
            this.firstOperator = operator;
            this.lastInputType = LastInputType.Operator;
            setCalculationState();
            return;
        }

        this.lastInputType = LastInputType.Equal;
        setCalculationState();
    }

    public String getCalculationState() {
        if (this.firstOperator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return "";
        return this.calculationState;
    }

    public String getOutputNumber() {
        return this.outputNumber;
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
    }

    private boolean isMaxInputNumberList() {
        if (outputNumber.contains(Constants.POINT_STRING))
            return this.outputNumber.length() >= 17;
        return this.outputNumber.length() >= 16;
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

    private void setCalculationState() {
        if (this.lastInputType == LastInputType.Operator) {
            this.firstNumber = new BigDecimal(this.outputNumber);
            this.calculationState = this.firstNumber + this.firstOperator;
            System.out.println(this.calculationState);
            return;
        }

        // lastInputType == LastInputType.equal 일 때
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
                if (!isProcessDivide(secondNumber))
                    return;
                break;
        }
    }

    private boolean isProcessDivide(BigDecimal secondNumber) {
        if (Objects.equals(secondNumber, new BigDecimal("0"))) {    // 0으로 나눴을 때
            this.calculationState = this.firstNumber + this.firstOperator;

            if (Objects.equals(this.firstNumber, new BigDecimal("0")))
                this.outputNumber = "정의되지 않은 결과입니다";
            else
                this.outputNumber = "0으로 나눌 수 없습니다";
            return false;
        }

        // 정상적으로 나눴을 때
        this.outputNumber = this.firstNumber.divide(secondNumber).toString();
        return true;
    }
}