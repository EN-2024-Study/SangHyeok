package observer;

import controller.ScreenManager;
import model.CalculationRepository;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ButtonListener implements ActionListener {

    private ScreenManager screenManager;
    private CalculationRepository calculationRepository;

    public ButtonListener(ScreenManager screenManager, CalculationRepository calculationRepository) {
        this.screenManager = screenManager;
        this.calculationRepository = calculationRepository;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource().getClass().toString().contains(Constants.HISTORY_BUTTON)) {
            screenManager.showDownHistoryPanel();
            screenManager.addTopPanelMouseListener();
        }
        else if (e.getSource().getClass().toString().contains(Constants.TRASH_BUTTON))
            calculationRepository.deleteHistory();
    }
}
