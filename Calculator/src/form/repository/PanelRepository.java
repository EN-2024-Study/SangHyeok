package form.repository;

import listener.ButtonListener;
import listener.KeypadListener;
import form.panel.historyPanel.DownHistoryPanel;
import form.panel.historyPanel.RightHistoryPanel;
import form.panel.mainPanel.BigNumberPanel;
import form.panel.mainPanel.HistoryButtonPanel;
import form.panel.mainPanel.KeypadPanel;
import form.panel.mainPanel.SmallNumberPanel;

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
