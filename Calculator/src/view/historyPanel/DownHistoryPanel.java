package view.historyPanel;

import javax.swing.*;
import java.awt.*;

public class DownHistoryPanel extends JPanel {

    private HistoryScrollPanel historyScrollPanel;

    public DownHistoryPanel() {
        historyScrollPanel = new HistoryScrollPanel();
        setBackground(Color.WHITE);
        initPanelByLayout();
    }

    private void initPanelByLayout() {
        setLayout(new BorderLayout());
        add(historyScrollPanel, BorderLayout.CENTER);
        add(historyScrollPanel.getDeletePanel(), BorderLayout.SOUTH);
    }
}
