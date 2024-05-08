package controller;

import utility.Constants;

import model.CalculationRepository;

public class CalculationManager {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;

    public CalculationManager(ScreenManager screenManager, CalculationRepository calculationRepository) {
        this.screenManager = screenManager;
        this.calculationRepository = calculationRepository;
    }

    public void addNumber(int number) {
        if (calculationRepository.isEmptyInputNumberList() && number != 0)
            screenManager.setBigNumber(true, String.valueOf(number));
        else if (!calculationRepository.isEmptyInputNumberList())
            screenManager.setBigNumber(false, String.valueOf(number));
        else if (number == 0)
            return;
        calculationRepository.addNumber(number);
    }

    public void deleteHistory() {
        calculationRepository.deleteHistory();
    }

    public void processOperation(String operation) {
        switch (operation) {
            case Constants.ADD_STRING:
            case Constants.SUBTRACT_STRING:
            case Constants.DIVIDE_STRING:
            case Constants.MULTIPLY_STRING:
            case Constants.CE_STRING:
            case Constants.C_STRING:
            case Constants.DELETE_STRING:
            case Constants.SIGN_STRING:
            case Constants.POINT_STRING:
            case Constants.EQUAL_STRING:
                break;
        }
    }
}
