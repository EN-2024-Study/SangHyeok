package Model;

import javax.swing.*;

public class PanelVo {

    private JPanel topPanel, smallNumberPanel, bigNumberPanel, keypadPanel, historyPanel;

    public PanelVo (JPanel topPanel, JPanel smallNumberPanel, JPanel bigNumberPanel, JPanel keypadPanel, JPanel historyPanel) {
        this.topPanel = topPanel;
        this.smallNumberPanel = smallNumberPanel;
        this.bigNumberPanel = bigNumberPanel;
        this.keypadPanel = keypadPanel;
        this.historyPanel = historyPanel;
    }

    public JPanel getTopPanel() {
        return topPanel;
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
