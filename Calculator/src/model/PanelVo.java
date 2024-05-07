package model;

import view.historyPanel.EarlyHistoryPanel;
import view.mainPanel.*;

import javax.swing.*;

public class PanelVo {

    private JPanel historyButtonPanel, smallNumberPanel, bigNumberPanel, keypadPanel, earlyHistoryPanel;

    public PanelVo (JPanel historyButtonPanel, JPanel smallNumberPanel, JPanel bigNumberPanel, JPanel keypadPanel, JPanel earlyHistoryPanel) {
        this.historyButtonPanel = historyButtonPanel;
        this.smallNumberPanel = smallNumberPanel;
        this.bigNumberPanel = bigNumberPanel;
        this.keypadPanel = keypadPanel;
        this.earlyHistoryPanel = earlyHistoryPanel;
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
    public EarlyHistoryPanel getEarlyHistoryPanel() {
        return (EarlyHistoryPanel) earlyHistoryPanel;
    }
}
