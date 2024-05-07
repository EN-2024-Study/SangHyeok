package model;

import view.historyPanel.RightHistoryPanel;
import view.mainPanel.*;

import javax.swing.*;

public class PanelVo {

    private JPanel historyButtonPanel, smallNumberPanel, bigNumberPanel, keypadPanel, rightHistoryPanel;

    public PanelVo (JPanel historyButtonPanel, JPanel smallNumberPanel, JPanel bigNumberPanel, JPanel keypadPanel, JPanel rightHistoryPanel) {
        this.historyButtonPanel = historyButtonPanel;
        this.smallNumberPanel = smallNumberPanel;
        this.bigNumberPanel = bigNumberPanel;
        this.keypadPanel = keypadPanel;
        this.rightHistoryPanel = rightHistoryPanel;
    }

    public HistoryButtonPanel getHistoryButtonPanel() {
        return (HistoryButtonPanel) historyButtonPanel;
    }
    public SmallNumberPanel getSmallNumberPanel() {
        return (SmallNumberPanel) smallNumberPanel;
    }
    public BigNumberPanel getBigNumberPanel() {
        return (BigNumberPanel) bigNumberPanel;
    }
    public KeypadPanel getKeypadPanel() {
        return (KeypadPanel) keypadPanel;
    }
    public RightHistoryPanel getRightHistoryPanel() {
        return (RightHistoryPanel) rightHistoryPanel;
    }
}
