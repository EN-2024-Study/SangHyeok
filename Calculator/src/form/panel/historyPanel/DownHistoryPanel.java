package form.panel.historyPanel;

import listener.ButtonListener;
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
        this.historyDeleteButtonPanel = new HistoryDeleteButtonPanel(buttonListener);
        setHistoryList(buttonListener, new ArrayList<>());
        setScrollPane();
        setHistoryPanel(buttonListener);
    }

    public void setHistoryList(ButtonListener buttonListener, List<String> historyStringList) {
        this.historyList = new ArrayList<JButton>();

        if (historyStringList.isEmpty()) {
            initButton(buttonListener, "아직 기록이 없음");
            return;
        }

        for (String history : historyStringList)
            initButton(buttonListener, history);
    }

    public void setScrollPane() {
        JPanel panel = new JPanel();
        panel.setLayout(new GridLayout(this.historyList.size(), 1));
        for(JButton button : this.historyList)
            panel.add(button);

        this.scrollPane = new JScrollPane(panel);
        this.scrollPane.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));
    }

    public void setHistoryPanel(ButtonListener buttonListener) {
        removeAll();
        setLayout(new BorderLayout());
        add(this.scrollPane, BorderLayout.CENTER);
        add(this.historyDeleteButtonPanel, BorderLayout.SOUTH);
    }

    private void initButton(ButtonListener buttonListener, String str) {
        JButton button = new JButton("<html>" + str.replaceAll("\\n", "<br>") + "</html>");
        button.setBackground(Color.WHITE);
        button.setOpaque(true);
        button.setBorderPainted(false);
        button.addActionListener(buttonListener);
        this.historyList.add(button);
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