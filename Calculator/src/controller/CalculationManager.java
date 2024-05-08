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
        calculationRepository.addNumber(number);
    }

    public void deleteHistory() {
        calculationRepository.deleteHistory();
        System.out.println("Test");
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
