package listener;

import controller.CalculationManager;
import view.ScreenManager;
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
        if (e.getSource().getClass().toString().contains(Constants.HISTORY_BUTTON_PANEL)) {
            screenManager.showDownHistoryPanel();
            screenManager.processTopPanelMouseListener(true);
        } else if (e.getActionCommand().contains(Constants.TRASH_BUTTON))
            calculationManager.deleteHistory();
    }
}
