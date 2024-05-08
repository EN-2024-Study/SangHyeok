package observer;

import controller.ScreenManager;
import model.CalculationRepository;
import utility.Constants;

import java.awt.event.*;

public class KeypadListener extends KeyAdapter implements ActionListener {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;
    private boolean isShift;

    public KeypadListener(ScreenManager screenManager, CalculationRepository calculationRepository) {
        this.screenManager = screenManager;
        this.calculationRepository = calculationRepository;
        this.isShift = false;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        boolean isDigit = false;

        for (String item : Constants.NUMBER_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                isDigit = true;
                calculationRepository.addNumber(Integer.parseInt(item));
                break;
            }
        }

        if (!isDigit)
            processOperation(e.getActionCommand());
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
            calculationRepository.addNumber((int) e.getKeyChar() - 48);
            return;
        } else if (e.getKeyCode() == 8) // delete
            operation = "⌫";
        else if (e.getKeyCode() == 27)  // esc
            operation = "C";
        else if (e.getKeyCode() == 120) // F9
            operation = "±";
        else if (e.getKeyCode() == 45)
            operation = "-";
        else if (e.getKeyCode() == 47)
            operation = "÷";
        else if (e.getKeyCode() == 46)
            operation = ".";
        else if (e.getKeyCode() == 61) {
            if (isShift)
                operation = "+";
            else
                operation = "=";
            isShift = false;
        }

        processOperation(operation);
    }

    private void processOperation(String operation) {
        if (!isKeypadValid(operation))
            return;

        switch (operation) {
            case "+":
            case "-":
            case "÷":
            case "×":
            case "CE":
            case "C":
            case "⌫":
            case "±":
            case ".":
            case "=":
                break;
        }
    }

    private boolean isKeypadValid(String str) {
        boolean isKeypad = false;

        for (String item : Constants.KEYPAD_STRINGS) {
            if (item.equals(str)) {
                isKeypad = true;
                break;
            }
        }
        return isKeypad;
    }
}
