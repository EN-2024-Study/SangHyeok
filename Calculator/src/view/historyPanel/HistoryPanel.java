package view.historyPanel;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class HistoryPanel extends JPanel {

    private JScrollPane scrollPane;
    private List<JButton> historyButtonList;

    public HistoryPanel() {
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
        panel.setLayout(new GridLayout(5, 1));
        for(JButton button : historyButtonList) {
            panel.add(button);
        }
        scrollPane = new JScrollPane(panel);
        scrollPane.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));
    }
}
