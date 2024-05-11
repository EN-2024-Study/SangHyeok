package controller;

import model.HistoryRepository;
import utility.Constants;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.Objects;

public class CalculationManager {

    private enum LastInputType {
        InitialValue, Number, Equal, Operator
    }

    private HistoryRepository historyRepository;
    private String outputNumber;
    private String firstOperator, secondOperator;
    private String calculationState;
    private BigDecimal firstNumber, secondNumber;
    private LastInputType lastInputType;

    public CalculationManager() {
        this.historyRepository = new HistoryRepository();
        processC();
    }

    public void processC() {
        this.outputNumber = "0";
        this.firstOperator = "";
        this.secondOperator = "";
        this.calculationState = " ";
        this.firstNumber = new BigDecimal("0");
        this.secondNumber = new BigDecimal("0");
        this.lastInputType = LastInputType.InitialValue;
    }

    public void processInputNumber(String number) {
        if (this.lastInputType == LastInputType.Operator || this.lastInputType == LastInputType.Equal)   // 연산자가 나온 직후 숫자가 들어왔을 때
            this.outputNumber = "0";

        this.lastInputType = LastInputType.Number;
        addInputNumber(number);
    }

    public void processOperator(String operator) {
        if (this.lastInputType == LastInputType.Operator || this.firstOperator.isEmpty())   // 연산자가 연속입력일 때 연산자만 바꾸기
            this.firstOperator = operator;
        else
            this.secondOperator = operator;

        this.lastInputType = LastInputType.Operator;
        setCalcStateByOperator();
        this.outputNumber = this.firstNumber.toString();    // 마지막 입력이 소수점이였을 때 연산자가 들어오면 소수점 삭제
    }

    public void processDelete() {
        if (this.lastInputType == LastInputType.Operator)  // 연산자가 나온 직후이면 return
            return;
        else if (this.lastInputType == LastInputType.Equal) {   // '='이 나온 직후이면 계산 식 초기화
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
            setCalcStateByOperator();
            return;

        } else if (this.lastInputType == LastInputType.Equal)
            this.firstNumber = new BigDecimal(this.outputNumber);
        else if (this.lastInputType == LastInputType.Operator) {
            this.secondNumber = this.firstNumber;
        }

        this.lastInputType = LastInputType.Equal;
        setCalcStateByEqual();
    }

    public String getCalculationState() {
        if (this.firstOperator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return " ";
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
        setOperand();
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
                    setOperand();
                    return true;
                }
            }
        }
        return false;
    }

    private void setOperand() {
        if (this.firstOperator.isEmpty())
            this.firstNumber = new BigDecimal(this.outputNumber);
        else
            this.secondNumber = new BigDecimal(this.outputNumber);
    }

    private void setCalcStateByEqual() {
        if (firstOperator.equals(Constants.EQUAL_STRING))   // "number = number =" 경우 return
            return;

        // "number operator number ="
        this.calculationState = this.firstNumber + this.firstOperator + this.secondNumber + Constants.EQUAL_STRING;
        calculate();
//        this.secondNumber = this.firstNumber;
    }

    private void setCalcStateByOperator() {
        if (this.secondOperator.isEmpty()) {    // 연산자가 한개만 들어온 상태
            this.calculationState = this.firstNumber + this.firstOperator;
            return;
        }

        // 연산자가 두개 들어온 상태
        calculate();
        this.calculationState = this.firstNumber + this.secondOperator;
        this.firstOperator = this.secondOperator;
        this.secondOperator = "";
    }

    private void calculate() {
        switch (firstOperator) {
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
        this.outputNumber = this.firstNumber.toString();
    }

    private void processDivide() {
        if (!isDivideValid())    // 0으로 나눴을 때
            return;

        // 정상적으로 나눴을 때
        int scaleSize = 16;
        this.firstNumber = this.firstNumber.divide(this.secondNumber, scaleSize, RoundingMode.HALF_EVEN);

        while (this.firstNumber.toString().length() > 17)
            this.firstNumber = this.firstNumber.divide(this.secondNumber, --scaleSize, RoundingMode.HALF_EVEN);

        this.outputNumber = this.firstNumber.stripTrailingZeros().toString();
    }

    private boolean isDivideValid() {
        if (Objects.equals(this.secondNumber, new BigDecimal("0"))) {    // 0으로 나눴을 때
            this.calculationState = this.firstNumber + this.firstOperator;

            if (Objects.equals(this.firstNumber, new BigDecimal("0")))
                this.outputNumber = "정의되지 않은 결과입니다";
            else
                this.outputNumber = "0으로 나눌 수 없습니다";
            return false;
        }
        return true;
    }
}