package controller;

import utility.Constants;

import model.CalculationRepository;
import view.ScreenManager;

public class CalculationManager {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;

    public CalculationManager(ScreenManager screenManager) {
        this.screenManager = screenManager;
        this.calculationRepository = new CalculationRepository();
    }

    public void addInputNumber(Character number) {
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

                break;
            case Constants.SUBTRACT_STRING:

                break;
            case Constants.DIVIDE_STRING:

                break;
            case Constants.MULTIPLY_STRING:

                break;
            case Constants.CE_STRING:
            case Constants.C_STRING:
                calculationRepository.clearInputNumberList();
                screenManager.resetBigNumber();
                break;
            case Constants.DELETE_STRING:
                processDelete();
                break;
            case Constants.SIGN_STRING:

                break;
            case Constants.POINT_STRING:
                processPoint(operation);
                break;
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

    private void processPoint(String operation) {
        if (calculationRepository.hasDecimalPoint())
            return;
        calculationRepository.addInputNumber(operation.charAt(0));
        screenManager.setBigNumber(operation);
    }
}
