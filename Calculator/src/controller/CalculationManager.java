package controller;

import model.CalculationRepository;

public class CalculationManager {

    private CalculationRepository calculationRepository;

    public CalculationManager() {
        this.calculationRepository = new CalculationRepository();
    }

    public void processInputNumber(String number) {
        if (calculationRepository.isEmptyInputNumberList() && number.equals("0"))
            return;  // 첫 문자가 0 일 때 그냥 반환

        calculationRepository.addInputNumber(number);
    }

    public void processAdd() {

    }

    public void processC() {
        calculationRepository.clearInputNumber();
    }

    public void processDelete() {
        calculationRepository.deleteInputNumber();
    }

    public void processPoint(String operator) {
        calculationRepository.addDecimalPoint(operator);
    }

    public void deleteHistory() {
        calculationRepository.clearHistoryList();
    }

    public String getInputNumber() {
        return calculationRepository.getInputNumber();
    }
}
