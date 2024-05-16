package listener;

import controller.CalculationManager;
import controller.PanelManager;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class ButtonListener implements ActionListener {

    private PanelManager panelManager;
    private CalculationManager calculationManager;

    public ButtonListener(PanelManager panelManager, CalculationManager calculationManager) {
        this.panelManager = panelManager;
        this.calculationManager = calculationManager;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource().getClass().toString().contains(Constants.HISTORY_BUTTON_PANEL)) {
            this.panelManager.showDownHistoryPanel();
            this.panelManager.processTopPanelMouseListener(true);
            return;
        } else if (e.getActionCommand().contains(Constants.TRASH_BUTTON)) {
            this.calculationManager.deleteHistory();
            this.panelManager.processHistoryScreen(new ArrayList<String>());
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
        this.panelManager.setBigNumber(this.calculationManager.getOutputNumber(), false);
        this.panelManager.setSmallNumber(this.calculationManager.getCalculationState());
        this.panelManager.setFrameFocus();
    }
}
