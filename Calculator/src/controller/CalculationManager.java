package controller;

import utility.Constants;

import model.CalculationRepository;

public class CalculationManager {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;

    public CalculationManager(ScreenManager screenManager) {
        this.screenManager = screenManager;
        this.calculationRepository = new CalculationRepository();
    }

    public void addInputNumber(int number) {
        if (calculationRepository.isMaxInputNumberList())
            return;
        else if (calculationRepository.isEmptyInputNumberList() && number == 0)
            return;

        calculationRepository.addInputNumber(number);
        screenManager.setBigNumber(String.valueOf(number));
    }

    public void deleteHistory() {
        calculationRepository.clearHistoryList();
    }

    public void processOperation(String operation) {
        switch (operation) {
            case Constants.ADD_STRING:
            case Constants.SUBTRACT_STRING:
            case Constants.DIVIDE_STRING:
            case Constants.MULTIPLY_STRING:
                break;
            case Constants.CE_STRING:
            case Constants.C_STRING:
                calculationRepository.clearInputNumberList();
                screenManager.resetBigNumber();
                break;
            case Constants.DELETE_STRING:
                processDelete();
            case Constants.SIGN_STRING:
            case Constants.POINT_STRING:
            case Constants.EQUAL_STRING:
                break;
        }
    }

    private void processDelete() {
        if (calculationRepository.isEmptyInputNumberList())
            return;
        calculationRepository.deleteInputNumber();
        screenManager.deleteBigNumber();
    }

}