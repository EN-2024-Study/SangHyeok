package view.historyPanel;

import observer.ButtonActionListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;

public class RightHistoryPanel extends JPanel {

    public RightHistoryPanel() {
        setBackground(Color.WHITE);
        initPanelByLayout(getExplainPanel(), getDeletePanel());
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

    private JPanel getDeletePanel() {
        JPanel deletePanel = new JPanel();
        deletePanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
        deletePanel.setBackground(Color.WHITE);

        JButton deleteButton = new JButton(Constants.TRASH);
        deleteButton.addActionListener(new ButtonActionListener());
        deleteButton.setBorderPainted(false);

        deletePanel.add(deleteButton);
        return deletePanel;
    }

    private void initPanelByLayout(JPanel explainPanel, JPanel deletePanel) {
        setLayout(new BorderLayout());
        add(explainPanel, BorderLayout.NORTH);
        add(new HistoryPanel(), BorderLayout.CENTER);
        add(deletePanel, BorderLayout.SOUTH);
    }
}