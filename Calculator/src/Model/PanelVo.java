package Model;

import javax.swing.*;

public class PanelVo {

    private JPanel historyButtonPanel, smallNumberPanel, bigNumberPanel, keypadPanel, historyPanel;

    public PanelVo (JPanel historyButtonPanel, JPanel smallNumberPanel, JPanel bigNumberPanel, JPanel keypadPanel, JPanel historyPanel) {
        this.historyButtonPanel = historyButtonPanel;
        this.smallNumberPanel = smallNumberPanel;
        this.bigNumberPanel = bigNumberPanel;
        this.keypadPanel = keypadPanel;
        this.historyPanel = historyPanel;
    }

    public JPanel getHistoryButtonPanel() {
        return historyButtonPanel;
    }
    public JPanel getSmallNumberPanel() {
        return smallNumberPanel;
    }
    public JPanel getBigNumberPanel() {
        return bigNumberPanel;
    }
    public JPanel getKeypadPanel() {
        return keypadPanel;
    }
    public JPanel getHistoryPanel() {
        return historyPanel;
    }
}
