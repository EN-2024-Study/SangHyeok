package listener;

import controller.CalculationManager;
import controller.ScreenManager;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

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
            this.screenManager.processHistoryScreen(new ArrayList<String>());
            return;
        }

        // HistoryPanel 의 historyButton click 일 때
        processPreviousState(e.getActionCommand());
    }

    private void processPreviousState(String str) {
        String[] parsingStrings = str.split("<br>");
        String calculateState = parsingStrings[0].substring(6);
        String answer = parsingStrings[1].substring(0, parsingStrings[1].length() - 7);

        String[] operators = Constants.OPERATORS;
        String operator = "";
        boolean isBreak = false;
        for (int i = 0; i < calculateState.length(); i++) {
            for (String o : operators) {
                if (calculateState.charAt(i) == o.charAt(0)) {
                    operator = o;
                    isBreak = true;
                    break;
                }
            }

            if (isBreak)
                break;
        }

        this.calculationManager.setPreviousCalculationState(calculateState, operator, answer);
        this.screenManager.setBigNumber(this.calculationManager.getOutputNumber(), false);
        this.screenManager.setSmallNumber(this.calculationManager.getCalculationState());
        this.screenManager.setFrameFocus();
    }
}
