package form.repository;

import listener.ButtonListener;
import listener.KeypadListener;
import form.panel.HistoryPanel;
import form.panel.HistoryButtonPanel;
import form.panel.KeypadPanel;
import form.panel.NumberPanel;

import javax.swing.*;

public class PanelRepository {

    private final JPanel historyButtonPanel, smallNumberPanel, bigNumberPanel, keypadPanel, rightHistoryPanel, downHistoryPanel;

    public PanelRepository(ButtonListener buttonListener, KeypadListener keypadListener) {
        this.historyButtonPanel = new HistoryButtonPanel(buttonListener);
        this.rightHistoryPanel = new HistoryPanel(buttonListener, true);
        this.downHistoryPanel = new HistoryPanel(buttonListener, false);
        this.keypadPanel = new KeypadPanel(keypadListener);
        this.smallNumberPanel = new NumberPanel(false);
        this.bigNumberPanel = new NumberPanel(true);
    }

    public HistoryButtonPanel getHistoryButtonPanel() {
        return (HistoryButtonPanel) historyButtonPanel;
    }

    public NumberPanel getSmallNumberPanel() {
        return (NumberPanel) smallNumberPanel;
    }

    public NumberPanel getBigNumberPanel() {
        return (NumberPanel) bigNumberPanel;
    }

    public KeypadPanel getKeypadPanel() {
        return (KeypadPanel) keypadPanel;
    }

    public HistoryPanel getRightHistoryPanel() {
        return (HistoryPanel) rightHistoryPanel;
    }

    public HistoryPanel getDownHistoryPanel() {
        return (HistoryPanel) downHistoryPanel;
    }
}
