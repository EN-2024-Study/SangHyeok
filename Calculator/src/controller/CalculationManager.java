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

    public void addInputNumber(String number) {
        if (calculationRepository.isEmptyInputNumberList() && number.equals("0"))
            return; // 첫 문자가 0 일 때 그냥 반환
        calculationRepository.addInputNumber(number);
        screenManager.setBigNumber(calculationRepository.getInputNumber());
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
        calculationRepository.deleteInputNumber();
        screenManager.setBigNumber(calculationRepository.getInputNumber());
    }

    private void processPoint(String operation) {
        calculationRepository.addDecimalPoint(operation);
        screenManager.setBigNumber(calculationRepository.getInputNumber());
    }
}
