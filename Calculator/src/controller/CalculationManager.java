package controller;

import model.CalculationRepository;

public class CalculationManager {

    private CalculationRepository calculationRepository;
    private boolean isSettingFirstOperand;

    public CalculationManager() {
        this.calculationRepository = new CalculationRepository();
        this.isSettingFirstOperand = false;
    }

    public void processInputNumber(String number) {
        if (calculationRepository.getFirstOperator().isEmpty() ||
                isSettingFirstOperand) {    // 연산자가 나오지 않았거나 이미 첫번째 연산자가 나왔을 때
            calculationRepository.addInputNumber(number);   // 숫자 삽입
            return;
        }

        calculationRepository.setFirstOperand();    // 연산자가 나오고 나서 처음 숫자 입력을 받을 때
        calculationRepository.addInputNumber(number);
        isSettingFirstOperand = true;
    }

    public void processOperator(String operator) {
        calculationRepository.setFirstOperator(operator);
    }

    public void processC() {
        calculationRepository.clearInputNumber();

        isSettingFirstOperand = false;
    }

    public void processDelete() {
        calculationRepository.deleteInputNumber();
    }

    public void processPoint(String operator) {
        calculationRepository.addDecimalPoint(operator);
    }

    public void processEqual(String operator) {
        if (calculationRepository.getFirstOperator().isEmpty()) {   // 첫번 째 연산자가 '='일 때
            calculationRepository.setFirstOperator(operator);
            return;
        }

        calculationRepository.setEqual(true);   // 두번 째 연산자가 '='일 때
        calculationRepository.setCalculationState();
        isSettingFirstOperand = false;
    }

    public String getCalculationState() {
        String firstOperator = calculationRepository.getFirstOperator();

        if (firstOperator.isEmpty())    // 연산자가 아직 나오지 않았다면 빈 문자열 반환
            return "";
        else if (calculationRepository.hasEqual())    // 연산자와 '='이 나왔다면
            return calculationRepository.getCalculationState();
        return calculationRepository.getFirstOperand().toString() + firstOperator;   // 첫번 째 연산자만 나왔을 때 숫자와 연산자 반환
    }

    public String getInputNumber() {
        return calculationRepository.getInputNumber();
    }

    public void deleteHistory() {
        calculationRepository.clearHistoryList();
    }
}
