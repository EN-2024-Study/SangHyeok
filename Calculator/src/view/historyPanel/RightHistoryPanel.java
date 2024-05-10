package view.historyPanel;

import Listener.ButtonListener;

import javax.swing.*;
import java.awt.*;

public class RightHistoryPanel extends DownHistoryPanel {

    public RightHistoryPanel(ButtonListener buttonListener) {
        super(buttonListener);
        super.add(getExplainPanel(), BorderLayout.NORTH);
    }

    private JPanel getExplainPanel() {
        JPanel explainPanel = new JPanel();
        explainPanel.setLayout(new GridLayout(1, 1));
        explainPanel.setBackground(Color.WHITE);
        explainPanel.setPreferredSize(new Dimension(getWidth(), getHeight() + 80));

        JLabel label = new JLabel("기록");
        label.setFont(new Font(Font.DIALOG, Font.PLAIN, 26));

        explainPanel.add(label);
        return explainPanel;
    }
}