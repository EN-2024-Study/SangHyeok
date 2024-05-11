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

    public void processEqual(String operator) {
        if (calculationRepository.getFirstOperator().isEmpty()) {
            calculationRepository.setFirstOperator(operator);
        }
        calculationRepository.setEqual(true);
    }

    public String getCalculationState() {
        String result = calculationRepository.getInputNumber();
        String firstOperator = calculationRepository.getFirstOperator();
        boolean equal = calculationRepository.hasEqual();

        if (firstOperator.isEmpty())
            return "";
        else if (!equal)
            return result + firstOperator;
        else
            return result + firstOperator + result;
    }

    public String getInputNumber() {
        return calculationRepository.getInputNumber();
    }

    public void deleteHistory() {
        calculationRepository.clearHistoryList();
    }
}
