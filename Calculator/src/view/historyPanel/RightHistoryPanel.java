package view.historyPanel;

import observer.ButtonListener;
import observer.KeypadListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class RightHistoryPanel extends JPanel {

    private HistoryScrollPanel historyScrollPanel;

    public RightHistoryPanel(ButtonListener buttonListener) {
        this.historyScrollPanel = new HistoryScrollPanel();
        setBackground(Color.WHITE);
        initPanelByLayout(buttonListener);
    }

    private void initPanelByLayout(ButtonListener buttonListener) {
        setLayout(new BorderLayout());

        add(getExplainPanel(), BorderLayout.NORTH);
        add(historyScrollPanel, BorderLayout.CENTER);
        add(historyScrollPanel.getDeletePanel(buttonListener), BorderLayout.SOUTH);
    }

    private JPanel getExplainPanel() {
        JPanel explainPanel = new JPanel();
        explainPanel.setLayout(new GridLayout(1, 1));
        explainPanel.setBackground(Color.WHITE);
        explainPanel.setPreferredSize(new Dimension(getWidth(), getHeight() + 80));

        JLabel label = new JLabel("기록");
        label.setFont(new Font(Font.DIALOG, Font.PLAIN, Constants.FONT_SIZE));

        explainPanel.add(label);
        return explainPanel;
    }
}