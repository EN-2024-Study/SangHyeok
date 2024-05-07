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
        switch(e.getActionCommand()) {
            case Constants.TRASH_BUTTON:
                screenManager.deleteHistory();
                break;
            case Constants.HISTORY_BUTTON:
                screenManager.showDonwHistoryPanel();
                break;
        }

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
}
