package view.historyPanel;

import utility.Constants;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class HistoryScrollPanel extends JPanel {

    private JScrollPane scrollPane;
    private List<JButton> historyButtonList;

    public HistoryScrollPanel() {
        initHistoryButtonList();
        initScrollPane();
        setLayout(new GridLayout(1, 1));
        add(scrollPane);
    }

    private void initHistoryButtonList() {
        historyButtonList = new ArrayList<>();
        for(int i = 0; i < 5; i++) {
            JButton button = new JButton("test" + (i + 1));
            button.setBackground(Color.WHITE);
            button.setOpaque(true);
            button.setBorderPainted(false);
            historyButtonList.add(button);
        }
    }

    private void initScrollPane() {
        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(historyButtonList.size(), 1));
        for(JButton button : historyButtonList)
            panel.add(button);

        scrollPane = new JScrollPane(panel);
        scrollPane.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));
    }

    public JPanel getDeletePanel() {
        JPanel deletePanel = new JPanel();
        deletePanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
        deletePanel.setBackground(Color.WHITE);

        JButton deleteButton = new JButton(Constants.TRASH_BUTTON);
        deleteButton.setBorderPainted(false);

        deletePanel.add(deleteButton);
        return deletePanel;
    }
}
