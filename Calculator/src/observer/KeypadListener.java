package observer;

import controller.ScreenManager;
import model.CalculationRepository;
import utility.Constants;

import java.awt.event.*;

public class KeypadListener extends KeyAdapter implements ActionListener {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;

    public KeypadListener(ScreenManager screenManager, CalculationRepository calculationRepository) {
        this.screenManager = screenManager;
        this.calculationRepository = calculationRepository;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        for(String item : Constants.BUTTON_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                if (item.chars().allMatch(Character::isDigit))
                    calculationRepository.addNumber(Integer.parseInt(item));
                else {
                    calculationRepository.setOperator(item);
                }
            }
        }
    }

    @Override
    public void keyReleased(KeyEvent e) {
        if (48 <= e.getKeyCode() && e.getKeyCode() <= 57)
            calculationRepository.addNumber((int) e.getKeyChar() - 48);
        else if (e.getKeyCode() == 8) { // delete key -> CE

        } else if (e.getKeyCode() == 27) {  // esc key -> C

        }
        System.out.println("keyCode = " + e.getKeyCode());
    }
}
