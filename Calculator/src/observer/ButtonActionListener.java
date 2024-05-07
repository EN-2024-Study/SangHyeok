package observer;

import controller.ScreenManager;
import model.CalculationRepository;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ButtonActionListener implements ActionListener {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;

    public ButtonActionListener(ScreenManager screenManager) {
        this.screenManager = screenManager;
        this.calculationRepository = new CalculationRepository();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        boolean isKeypad = false;

        for(String item : Constants.BUTTON_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                isKeypad = true;
                if (item.chars().allMatch(Character::isDigit))
                    calculationRepository.addNumber(Integer.parseInt(item));
                else {
                    calculationRepository.setOperator(item);
                }
            }
        }

        if (!isKeypad) {
            if (e.getSource().getClass().toString().contains("HistoryButtonPanel"))
                screenManager.showDownHistoryPanel();
            else if (e.getSource().getClass().toString().contains(Constants.TRASH_BUTTON))
                screenManager.deleteHistory();
        }
    }
}
