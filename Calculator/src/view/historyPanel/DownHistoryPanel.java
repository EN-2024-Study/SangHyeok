package view.historyPanel;

import Listener.ButtonListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class DownHistoryPanel extends JPanel {

    private JScrollPane scrollPane;
    private List<JButton> historyList;
    private HistoryDeleteButtonPanel historyDeleteButtonPanel;

    public DownHistoryPanel(ButtonListener buttonListener) {
        historyDeleteButtonPanel = new HistoryDeleteButtonPanel(buttonListener);
        initHistoryList();
        initScrollPane();
        setLayout(new BorderLayout());
        add(scrollPane, BorderLayout.CENTER);
        add(historyDeleteButtonPanel, BorderLayout.SOUTH);
    }

    private void initHistoryList() {
        historyList = new ArrayList<>();
        for(int i = 0; i < 5; i++) {
            JButton button = new JButton("test" + (i + 1));
            button.setBackground(Color.WHITE);
            button.setOpaque(true);
            button.setBorderPainted(false);
            historyList.add(button);
        }
    }

    private void initScrollPane() {
        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(historyList.size(), 1));
        for(JButton button : historyList)
            panel.add(button);

        scrollPane = new JScrollPane(panel);
        scrollPane.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));
    }

    private class HistoryDeleteButtonPanel extends JPanel {     // 1회성 Class

        private JButton deleteButton;

        public HistoryDeleteButtonPanel(ButtonListener buttonListener) {
            initButton(buttonListener);
            initPanel();
        }

        private void initPanel() {
            setLayout(new BorderLayout());
            setBackground(Color.WHITE);
            add(deleteButton, BorderLayout.EAST);
        }

        private void initButton(ButtonListener buttonListener) {
            deleteButton = new JButton(Constants.TRASH_BUTTON);
            deleteButton.addActionListener(buttonListener);
            deleteButton.setBorderPainted(false);
        }
    }
}
