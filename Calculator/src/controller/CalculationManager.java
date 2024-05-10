package controller;

import utility.Constants;

import model.CalculationRepository;
import view.ScreenManager;

public class CalculationManager {

    private CalculationRepository calculationRepository;

    public CalculationManager() {
        this.calculationRepository = new CalculationRepository();
    }

    public String addInputNumber(String number) {
        if (calculationRepository.isEmptyInputNumberList() && number.equals("0"))
            return calculationRepository.getInputNumber(); // 첫 문자가 0 일 때 그냥 반환

        calculationRepository.addInputNumber(number);
        return calculationRepository.getInputNumber();
    }

    public void deleteHistory() {
        calculationRepository.clearHistoryList();
    }

    public void processC() {
        calculationRepository.clearInputNumber();
    }

    public String processDelete() {
        calculationRepository.deleteInputNumber();
        return calculationRepository.getInputNumber();
    }

    public String processPoint(String operator) {
        calculationRepository.addDecimalPoint(operator);
        return calculationRepository.getInputNumber();
    }
}
