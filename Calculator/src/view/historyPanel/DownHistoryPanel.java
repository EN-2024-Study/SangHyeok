package view.historyPanel;

import observer.KeypadListener;

import javax.swing.*;
import java.awt.*;

public class DownHistoryPanel extends JPanel {

    private HistoryScrollPanel historyScrollPanel;

    public DownHistoryPanel(KeypadListener keypadListener) {
        historyScrollPanel = new HistoryScrollPanel();
        setBackground(Color.WHITE);
        initPanelByLayout(keypadListener);
    }

    private void initPanelByLayout(KeypadListener keypadListener) {
        setLayout(new BorderLayout());
        add(historyScrollPanel, BorderLayout.CENTER);
        add(historyScrollPanel.getDeletePanel(keypadListener), BorderLayout.SOUTH);
    }
}
