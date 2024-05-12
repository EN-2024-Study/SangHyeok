package view.repository;

import listener.ButtonListener;
import listener.KeypadListener;
import view.panel.historyPanel.DownHistoryPanel;
import view.panel.historyPanel.RightHistoryPanel;
import view.panel.mainPanel.BigNumberPanel;
import view.panel.mainPanel.HistoryButtonPanel;
import view.panel.mainPanel.KeypadPanel;
import view.panel.mainPanel.SmallNumberPanel;

import javax.swing.*;

public class PanelRepository {

    private final JPanel historyButtonPanel, smallNumberPanel, bigNumberPanel, keypadPanel, rightHistoryPanel, downHistoryPanel;

    public PanelRepository(ButtonListener buttonListener, KeypadListener keypadListener) {
        this.historyButtonPanel = new HistoryButtonPanel(buttonListener);
        this.rightHistoryPanel = new RightHistoryPanel(buttonListener);
        this.downHistoryPanel = new DownHistoryPanel(buttonListener);
        this.keypadPanel = new KeypadPanel(keypadListener);
        this.smallNumberPanel = new SmallNumberPanel();
        this.bigNumberPanel = new BigNumberPanel();
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
