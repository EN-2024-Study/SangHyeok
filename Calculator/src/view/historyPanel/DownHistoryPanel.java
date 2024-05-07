package view.historyPanel;

import observer.ButtonActionListener;
import view.mainPanel.Main;

import javax.swing.*;
import java.awt.*;

public class DownHistoryPanel extends JPanel {

    private HistoryScrollPanel historyScrollPanel;

    public DownHistoryPanel(ButtonActionListener buttonActionListener) {
        historyScrollPanel = new HistoryScrollPanel();
        setBackground(Color.WHITE);
        initPanelByLayout(buttonActionListener);
    }

    private void initPanelByLayout(ButtonActionListener buttonActionListener) {
        setLayout(new BorderLayout());
        add(historyScrollPanel, BorderLayout.CENTER);
        add(historyScrollPanel.getDeletePanel(buttonActionListener), BorderLayout.SOUTH);
    }
}
