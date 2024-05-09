package observer;

import controller.CalculationManager;
import controller.ScreenManager;
import model.CalculationRepository;
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
                calculationManager.addInputNumber(item.charAt(0));
                return;
            }
        }

        calculationManager.processOperation(e.getActionCommand());
    }

    @Override
    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode() == 16)   // shift
            isShift = true;
    }

    @Override
    public void keyReleased(KeyEvent e) {
        String operation = "";

        if (48 <= e.getKeyCode() && e.getKeyCode() <= 57) {
            calculationManager.addInputNumber(Character.forDigit(e.getKeyChar() - 48, 10));
            screenManager.processkeypadAction(String.valueOf(e.getKeyChar() - 48));
            return;
        } else if (e.getKeyCode() == 8) // delete
            operation = Constants.DELETE_STRING;
        else if (e.getKeyCode() == 27)  // esc
            operation = Constants.C_STRING;
        else if (e.getKeyCode() == 120) // F9
            operation = Constants.SIGN_STRING;
        else if (e.getKeyCode() == 45)  // -
            operation = Constants.SUBTRACT_STRING;
        else if (e.getKeyCode() == 47)  // /
            operation = Constants.DIVIDE_STRING;
        else if (e.getKeyCode() == 46)  // .
            operation = Constants.POINT_STRING;
        else if (e.getKeyCode() == 61) {
            if (isShift)
                operation = Constants.ADD_STRING;   // +
            else
                operation = Constants.EQUAL_STRING; // =
            isShift = false;
        }

        if (isOperatorValid(operation)) {
            calculationManager.processOperation(operation);
            screenManager.processkeypadAction(operation);
        }
    }

    private boolean isOperatorValid(String str) {
        for (String item : Constants.KEYPAD_STRINGS)
            if (item.equals(str))
                return true;
        return false;
    }
}
