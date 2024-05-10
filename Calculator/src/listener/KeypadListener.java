package listener;

import controller.CalculationManager;
import view.ScreenManager;
import utility.Constants;

import java.awt.event.*;

public class KeypadListener extends KeyAdapter implements ActionListener {

    private CalculationManager calculationManager;
    private ScreenManager screenManager;
    private boolean isShift;

    public KeypadListener(ScreenManager screenManager, CalculationManager calculationManager) {
        this.screenManager = screenManager;
        this.calculationManager = calculationManager;
        this.isShift = false;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        for (String item : Constants.NUMBER_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                String number = calculationManager.addInputNumber(item);
                screenManager.setBigNumber(number);
                return;
            }
        }

//        calculationManager.processOperator(e.getActionCommand());
        processOperator(e.getActionCommand());
    }

    @Override
    public void keyPressed(KeyEvent e) {
        String operator = "";

        if (e.getKeyCode() == 56) {     // 8과 곱셈 처리
            if (isShift)
                operator = Constants.MULTIPLY_STRING;
            else {
                String number = calculationManager.addInputNumber(String.valueOf(e.getKeyChar() - 48));
                screenManager.setBigNumber(number);
                screenManager.processKeypadAction(String.valueOf(e.getKeyChar() - 48));
            }
        }
        else if (48 <= e.getKeyCode() && e.getKeyCode() <= 57) {    // 숫자
            String number = calculationManager.addInputNumber(String.valueOf(e.getKeyChar() - 48));
            screenManager.setBigNumber(number);
            screenManager.processKeypadAction(String.valueOf(e.getKeyChar() - 48));
            return;
        } else if (e.getKeyCode() == 16)   // shift
            isShift = true;
        else if (e.getKeyCode() == 8) // delete
            operator = Constants.DELETE_STRING;
        else if (e.getKeyCode() == 27)  // esc
            operator = Constants.C_STRING;
        else if (e.getKeyCode() == 120) // F9
            operator = Constants.SIGN_STRING;
        else if (e.getKeyCode() == 45)  // -
            operator = Constants.SUBTRACT_STRING;
        else if (e.getKeyCode() == 46)  // .
            operator = Constants.POINT_STRING;
        else if (e.getKeyCode() == 47)  // /
            operator = Constants.DIVIDE_STRING;
        else if (e.getKeyCode() == 61) {
            if (isShift)
                operator = Constants.ADD_STRING;   // +
            else
                operator = Constants.EQUAL_STRING; // =
        }

        if (isOperatorValid(operator)) {
//            calculationManager.processOperator(operator);
            processOperator(operator);
            screenManager.processKeypadAction(operator);
        }
    }

    @Override
    public void keyReleased(KeyEvent e) {
        if (e.getKeyCode() == 16)   // shift
            isShift = false;
    }

    private void processOperator(String operator) {
        String number = "";
        switch (operator) {
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
                calculationManager.processC();
                screenManager.resetBigNumber();
                break;
            case Constants.DELETE_STRING:
                number = calculationManager.processDelete();
                screenManager.setBigNumber(number);
                break;
            case Constants.SIGN_STRING:

                break;
            case Constants.POINT_STRING:
                number = calculationManager.processPoint(operator);
                screenManager.setBigNumber(number);
                break;
            case Constants.EQUAL_STRING:

                break;
        }
    }

    private boolean isOperatorValid(String str) {
        for (String item : Constants.KEYPAD_STRINGS)
            if (item.equals(str))
                return true;
        return false;
    }
}
