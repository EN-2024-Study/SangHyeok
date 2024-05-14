package listener;

import controller.CalculationManager;
import form.ScreenManager;
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
            this.screenManager.showDownHistoryPanel();
            this.screenManager.processTopPanelMouseListener(true);
            return;
        } else if (e.getActionCommand().contains(Constants.TRASH_BUTTON)) {
            this.calculationManager.deleteHistory();
            return;
        }

        // HistoryPanel 의 historyButton click 일 때

    }
}
