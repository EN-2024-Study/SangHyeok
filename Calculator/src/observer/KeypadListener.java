package observer;

import controller.ScreenManager;
import model.CalculationRepository;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeypadListener implements ActionListener, KeyListener {

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
    public void keyTyped(KeyEvent e) {

    }

    @Override
    public void keyPressed(KeyEvent e) {

    }

    @Override
    public void keyReleased(KeyEvent e) {

    }
}
