package controller;

import model.CalculationRepository;

public class CalculationManager {

    private CalculationRepository calculationRepository;

    public CalculationManager() {
        this.calculationRepository = new CalculationRepository();
    }

    public void processInputNumber(String number) {
        calculationRepository.addInputNumber(number);
    }

    public void processOperator(String operator) {
        calculationRepository.setFirstOperator(operator);
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

//    public String getCalculationState() {
//
//    }
}
