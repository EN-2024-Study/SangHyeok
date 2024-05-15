package controller;

import utility.Constants;

import java.math.*;
import java.util.*;

public class CalculationManager {

    private enum LastInputType {
        InitialValue, Number, Equal, Operator
    }

    private StringTrimManager stringTrimManager;
    private Deque<String> historyQueue;
    private String outputNumber;
    private String operator;
    private String calculationState;
    private BigDecimal firstNumber, secondNumber;
    private LastInputType lastInputType;

    public CalculationManager() {
        this.stringTrimManager = new StringTrimManager();
        this.historyQueue = new ArrayDeque<>();
        processC();
    }

    public void initLastInputType() {
        this.lastInputType = LastInputType.InitialValue;
    }

    public void processC() {
        this.outputNumber = "0";
        this.operator = "";
        this.calculationState = " ";
        this.firstNumber = new BigDecimal("0");
        this.secondNumber = new BigDecimal("0");
        initLastInputType();
    }

    public void processCE() {
        if (this.lastInputType == LastInputType.Equal) {
            processC();
            return;
        }
        this.outputNumber = "0";
        this.secondNumber = new BigDecimal("0");
    }

    public void processInputNumber(String number) {
        if (this.lastInputType == LastInputType.Operator)   // 연산자가 나온 직후 숫자가 들어왔을 때
            this.outputNumber = "0";
        else if (this.lastInputType == LastInputType.Equal || this.lastInputType == LastInputType.InitialValue)
            processC();

        this.lastInputType = LastInputType.Number;
        addInputNumber(number);
    }

    public void processSign() {
        // 계산이 끝나고 나서일 때, 연산자가 =만 존재할 때
        if ((!this.operator.isEmpty() && this.lastInputType == LastInputType.Equal) ||
                (this.operator.equals(Constants.EQUAL_STRING) && !this.calculationState.contains(Constants.NEGATE)))
            this.calculationState = Constants.NEGATE + this.outputNumber + ")"; // negate(number)

        // 두번 째 숫자차례일 때
        else if (this.lastInputType == LastInputType.Operator)
            this.calculationState += Constants.NEGATE + this.outputNumber + ")";    // number operator negate(number)

        // 이미 계산 식에 negate 가 붙어있을 때
        else if (this.lastInputType == LastInputType.Number && this.calculationState.contains(Constants.NEGATE)) {

            if (this.operator.equals(Constants.EQUAL_STRING)) {
                this.calculationState = Constants.NEGATE + this.calculationState + ")"; // negate(negate(number))
            }
            else {
                String splitString = this.operator;
                if (this.operator.equals(Constants.ADD_STRING))
                    splitString = "\\+";

                String[] tempState = this.calculationState.split(splitString);
                if (tempState.length == 2)
                    this.calculationState = tempState[0] + this.operator + Constants.NEGATE + tempState[1] + ")";   // number operator negate(negate(number))
            }
        }

        this.outputNumber = new BigDecimal(this.outputNumber).negate().toString();
        this.lastInputType = LastInputType.Number;
    }

    public void processDelete() {
        if (this.lastInputType == LastInputType.InitialValue)
            processC();
        else if (this.lastInputType == LastInputType.Operator || this.calculationState.contains(Constants.NEGATE))  // 연산자가 나온 직후이면 return
            return;
        else if (this.lastInputType == LastInputType.Equal) {   // '='이 나온 직후이면 계산 식 초기화
            this.calculationState = " ";
            this.firstNumber = new BigDecimal("0");
            this.secondNumber = new BigDecimal("0");
            this.operator = "";
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
        if (this.lastInputType == LastInputType.Operator)  // 마지막 입력이 연산자였다면 "0."으로 삽입
            this.outputNumber = "0" + point;
        else if (this.outputNumber.contains(Constants.POINT_STRING))   // 이미 소수점이 있다면 return
            return;
        else
            this.outputNumber += point;

        this.lastInputType = LastInputType.Number;
    }

    public void processOperator(String operator) {
        if (this.lastInputType == LastInputType.Operator || this.lastInputType == LastInputType.Equal)    // 연산자가 연속입력일 때나 = 다음에 연산자 입력이 들어오면 연산자만 바꾸기
            this.operator = operator;
        else if (this.lastInputType == LastInputType.Number || this.lastInputType == LastInputType.InitialValue) {  // 숫자 입력 후 연산자 입력일 때
            if (this.operator.isEmpty())
                this.operator = operator;
            else if (this.operator.equals(Constants.EQUAL_STRING) && this.calculationState.contains(Constants.NEGATE)) {
                this.calculationState += operator;
                this.firstNumber = new BigDecimal(this.outputNumber);
                this.operator = operator;
                this.lastInputType = LastInputType.Operator;
                return;
            } else {
                calculate();
                this.operator = operator;
                this.secondNumber = new BigDecimal("0");
            }
        }

        this.lastInputType = LastInputType.Operator;
        this.firstNumber = new BigDecimal(this.outputNumber, MathContext.DECIMAL128);
        this.calculationState = this.firstNumber.toPlainString() + this.operator;

        if (outputNumber.charAt(outputNumber.length() - 1) == '.')
            this.outputNumber = this.firstNumber.toString();    // 마지막 입력이 소수점이였을 때 연산자가 들어오면 소수점 삭제
    }

    public void processEqual() {
        if (this.operator.isEmpty() || this.operator.equals(Constants.EQUAL_STRING)) {   // 연산자가 비어있거나 number = 일 때 연산자에 삽입
            if (this.calculationState.contains(Constants.NEGATE)) {

                if (!this.calculationState.contains(Constants.EQUAL_STRING)) {
                    this.calculationState += Constants.EQUAL_STRING;
                    addHistory(this.calculationState, this.outputNumber);
                    return;
                }
            }

            this.operator = Constants.EQUAL_STRING;
            this.lastInputType = LastInputType.Operator;
            this.calculationState = this.outputNumber + this.operator;
            addHistory(this.calculationState, this.outputNumber);
            return;

        } else if (this.lastInputType == LastInputType.Equal) // "number ==" 경우
            this.firstNumber = new BigDecimal(this.outputNumber);
        else if (this.lastInputType == LastInputType.Operator)     // 연산자 직후 "=" 경우
            this.secondNumber = new BigDecimal(this.outputNumber);

        this.lastInputType = LastInputType.Equal;
        this.calculationState = this.firstNumber.toPlainString() + this.operator + this.secondNumber.toPlainString() + Constants.EQUAL_STRING; // "number operator number ="
        calculate();
    }

    public String getCalculationState() {
        if (this.operator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return " ";
        return this.calculationState;
    }

    public void setPreviousCalculationState(String calculationState, String operator, String answer) {
        this.calculationState = calculationState;
        this.outputNumber = answer;
        this.operator = operator;

        this.lastInputType = LastInputType.Equal;
        this.firstNumber = new BigDecimal(this.outputNumber, MathContext.DECIMAL128);
    }

    public String getOutputNumber() {
        return this.outputNumber;
    }

    public List<String> getHistoryList() {
        return this.historyQueue.stream().toList();
    }

    public void deleteHistory() {
        this.historyQueue.clear();
    }

    private void addHistory(String state, String answer) {
        state = this.stringTrimManager.processE(state);
        answer = this.stringTrimManager.processE(answer);
        if (this.historyQueue.size() >= 20)
            this.historyQueue.removeFirst();

        this.historyQueue.addLast(state + '\n' + answer);
    }

    private void addInputNumber(String addNumber) {
        if (isMaxInputNumberList()) // 문자가 최대일 때 그냥 반환
            return;
        if (isFirstInput(addNumber))
            return;

        this.outputNumber += addNumber;
        setOperand();
    }

    private boolean isMaxInputNumberList() {
        if (outputNumber.contains(Constants.POINT_STRING))
            return this.outputNumber.length() >= Constants.NUMBER_MAX_LENGTH + 1;
        return this.outputNumber.length() >= Constants.NUMBER_MAX_LENGTH;
    }

    private boolean isFirstInput(String addNumber) {
        if (outputNumber.equals("0")) {
            if (addNumber.equals("0")) // 첫 숫자가 0이라면 저장하지 않고 종료
                return true;

            for (String n : Constants.NUMBER_STRINGS) {
                if (n.equals(addNumber)) {
                    this.outputNumber = addNumber;  // 첫 문자가 숫자라면 숫자 삽입
                    setOperand();
                    return true;
                }
            }
        }
        return false;
    }

    private void setOperand() {
        if (this.operator.isEmpty())
            this.firstNumber = new BigDecimal(this.outputNumber);
        else
            this.secondNumber = new BigDecimal(this.outputNumber);
    }

    private void calculate() {
        switch (operator) {
            case Constants.ADD_STRING:
                this.firstNumber = this.firstNumber.add(secondNumber);
                break;
            case Constants.SUBTRACT_STRING:
                this.firstNumber = this.firstNumber.subtract(secondNumber);
                break;
            case Constants.MULTIPLY_STRING:
                this.firstNumber = this.firstNumber.multiply(secondNumber);
                break;
            case Constants.DIVIDE_STRING:
                processDivide();
                return;
        }

        if (this.firstNumber.compareTo(new BigDecimal("1E+10000")) > 0)
            this.outputNumber = Constants.OVERFLOW;
        else
            this.outputNumber = this.firstNumber.toPlainString();

        addHistory(this.calculationState, this.outputNumber);
    }

    private void processDivide() {
        if (!isDivideValid())    // 0으로 나눴을 때
            return;

        // 정상적으로 나눴을 때
        this.firstNumber = this.firstNumber.divide(this.secondNumber, MathContext.DECIMAL128);
        this.outputNumber = this.firstNumber.toString();
    }

    private boolean isDivideValid() {
        this.firstNumber = this.firstNumber.stripTrailingZeros();
        this.secondNumber = this.secondNumber.stripTrailingZeros();

        if (Objects.equals(this.secondNumber, new BigDecimal("0"))) {    // 0으로 나눴을 때
            this.calculationState = this.firstNumber.toPlainString() + this.operator;

            if (Objects.equals(this.firstNumber, new BigDecimal("0")))
                this.outputNumber = Constants.WRONG_DIVIDED1;
            else
                this.outputNumber = Constants.WRONG_DIVIDED2;
            return false;
        }
        return true;
    }
}