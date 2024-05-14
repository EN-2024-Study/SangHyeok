package listener;

import controller.CalculationManager;
import controller.StringTrimManager;
import form.ScreenManager;
import utility.Constants;

import java.awt.event.*;

public class KeypadListener extends KeyAdapter implements ActionListener {

    private CalculationManager calculationManager;
    private ScreenManager screenManager;
    private StringTrimManager stringTrimManager;
    private boolean isShift;

    public KeypadListener(ScreenManager screenManager, CalculationManager calculationManager) {
        this.screenManager = screenManager;
        this.calculationManager = calculationManager;
        this.stringTrimManager = new StringTrimManager();
        this.isShift = false;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        for (String item : Constants.NUMBER_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                processNumber(item);
                return;
            }
        }

        processKey(e.getActionCommand());
    }

    @Override
    public void keyPressed(KeyEvent e) {
        String operator = "";
        if (e.getKeyCode() == 56) {     // 8과 곱셈 처리
            if (this.isShift)
                operator = Constants.MULTIPLY_STRING;
            else {
                processNumber(String.valueOf(e.getKeyChar() - 48));
                this.screenManager.processKeypadActionPaint(String.valueOf(e.getKeyChar() - 48));
                return;
            }
        } else if (48 <= e.getKeyCode() && e.getKeyCode() <= 57) {    // 숫자 처리
            processNumber(String.valueOf(e.getKeyChar() - 48));
            this.screenManager.processKeypadActionPaint(String.valueOf(e.getKeyChar() - 48));
            return;
        } else if (e.getKeyCode() == 16) {   // shift
            this.isShift = true;
            return;
        } else if (e.getKeyCode() == 8) // delete
            operator = Constants.DELETE_STRING;
        else if (e.getKeyCode() == 10) // enter
            operator = Constants.EQUAL_STRING;
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
            if (this.isShift)
                operator = Constants.ADD_STRING;   // +
            else
                operator = Constants.EQUAL_STRING; // =
        }

        if (isOperatorValid(operator)) {
            processKey(operator);
            this.screenManager.processKeypadActionPaint(operator);
        }
    }

    @Override
    public void keyReleased(KeyEvent e) {
        if (e.getKeyCode() == 16)   // shift
            this.isShift = false;
    }

    private void processKey(String operator) {
        switch (operator) {
            case Constants.ADD_STRING:
            case Constants.SUBTRACT_STRING:
            case Constants.DIVIDE_STRING:
            case Constants.MULTIPLY_STRING:
                this.calculationManager.processOperator(operator);
                break;
            case Constants.CE_STRING:
                this.calculationManager.processCE();
                break;
            case Constants.C_STRING:
                this.calculationManager.processC();
                break;
            case Constants.DELETE_STRING:
                this.calculationManager.processDelete();
                break;
            case Constants.SIGN_STRING:
                this.calculationManager.processSign();
                break;
            case Constants.POINT_STRING:
                this.calculationManager.processPoint(operator);
                processScreen(true);
                return;
            case Constants.EQUAL_STRING:
                this.calculationManager.processEqual(operator);
                break;
        }

        processKeypadAction();
        processScreen(false);
    }

    private boolean isOperatorValid(String str) {
        for (String item : Constants.KEYPAD_STRINGS)
            if (item.equals(str))
                return true;
        return false;
    }

    private void processNumber(String number) {
        this.calculationManager.processInputNumber(number);
        processKeypadAction();
        processScreen(true);
    }

    private void processScreen(boolean isInput) {
        String bigNumber = this.stringTrimManager.processComma(this.calculationManager.getOutputNumber());
        String smallNumber = this.stringTrimManager.processE(this.calculationManager.getCalculationState());

        if (!isInput) {
            bigNumber = this.stringTrimManager.processE(bigNumber);
            this.screenManager.processHistoryScreen(this.calculationManager.getHistoryList());
        }
        this.screenManager.setBigNumber(bigNumber);

        this.screenManager.setSmallNumber(smallNumber);
    }

    private void processKeypadAction() {
        if (!this.calculationManager.getOutputNumber().equals(Constants.WRONG_DIVIDED1) &&
        !this.calculationManager.getOutputNumber().equals(Constants.WRONG_DIVIDED2) &&
                !this.calculationManager.getOutputNumber().equals(Constants.OVERFLOW)) {
            this.screenManager.processKeypadActionListener(true);
            return;
        }

        this.screenManager.processKeypadActionListener(false);
        this.calculationManager.initLastInputType();
    }
}