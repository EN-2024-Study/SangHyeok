package view.historyPanel;

import observer.ButtonListener;
import observer.KeypadListener;

import javax.swing.*;
import java.awt.*;

public class DownHistoryPanel extends JPanel {

    private HistoryScrollPanel historyScrollPanel;

    public DownHistoryPanel(ButtonListener buttonListener) {
        historyScrollPanel = new HistoryScrollPanel();
        setBackground(Color.WHITE);
        initPanel(buttonListener);
    }

    private void initPanel(ButtonListener buttonListener) {
        setLayout(new BorderLayout());
        add(historyScrollPanel, BorderLayout.CENTER);
        add(historyScrollPanel.getDeletePanel(buttonListener), BorderLayout.SOUTH);
    }
}
