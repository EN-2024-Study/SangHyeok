package model;

import view.historyPanel.DownHistoryPanel;
import view.historyPanel.RightHistoryPanel;
import view.mainPanel.*;

import javax.swing.*;

public class PanelVo {

    private JPanel historyButtonPanel, smallNumberPanel, bigNumberPanel, keypadPanel, rightHistoryPanel, downHistoryPanel;

    public PanelVo (HistoryButtonPanel historyButtonPanel, SmallNumberPanel smallNumberPanel,
                    BigNumberPanel bigNumberPanel, KeypadPanel keypadPanel,
                    RightHistoryPanel rightHistoryPanel, DownHistoryPanel downHistoryPanel) {
        this.historyButtonPanel = historyButtonPanel;
        this.smallNumberPanel = smallNumberPanel;
        this.bigNumberPanel = bigNumberPanel;
        this.keypadPanel = keypadPanel;
        this.rightHistoryPanel = rightHistoryPanel;
        this.downHistoryPanel = downHistoryPanel;
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
    public DownHistoryPanel getDownHistoryPanel() {
        return (DownHistoryPanel) downHistoryPanel;
    }
}
