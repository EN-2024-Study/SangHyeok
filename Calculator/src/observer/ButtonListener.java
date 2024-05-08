package observer;

import controller.CalculationManager;
import controller.ScreenManager;
import model.CalculationRepository;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ButtonListener implements ActionListener {

    private ScreenManager screenManager;
    private CalculationManager calculationManager;

    public ButtonListener(ScreenManager screenManager, CalculationManager calculationManager) {
        this.screenManager = screenManager;
        this.calculationManager = calculationManager;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource().getClass().toString().contains(Constants.HISTORY_BUTTON)) {
            screenManager.showDownHistoryPanel();
            screenManager.addTopPanelMouseListener();
        }
        else if (e.getSource().getClass().toString().contains(Constants.TRASH_BUTTON))
            calculationManager.deleteHistory();
    }
}
