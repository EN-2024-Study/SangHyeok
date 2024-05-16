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
        setHistoryPanel();
    }

    public void setHistoryList(ButtonListener buttonListener, List<String> historyStringList) {
        this.historyList = new ArrayList<>();

        if (historyStringList.isEmpty()) {
            initButton(buttonListener, "아직 기록이 없음", false);
            return;
        }

        for (String history : historyStringList)
            initButton(buttonListener, history, true);
    }

    public void setScrollPane() {
        JPanel panel = new JPanel();
        panel.setBackground(Color.WHITE);
        panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));
        for(JButton button : this.historyList)
            panel.add(button, 0);

        this.scrollPane = new JScrollPane(panel);
        this.scrollPane.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));
    }

    public void setHistoryPanel() {
        removeAll();
        setLayout(new BorderLayout());
        add(this.scrollPane, BorderLayout.CENTER);
        add(this.historyDeleteButtonPanel, BorderLayout.SOUTH);
    }

    private void initButton(ButtonListener buttonListener, String str, boolean isRight) {
        JButton button = new JButton("<html>" + str.replaceAll("\\n", "<br>") + "</html>");
        button.setBackground(Color.WHITE);
        button.setOpaque(true);
        button.setBorderPainted(false);
        if (isRight)
            button.setHorizontalAlignment(SwingConstants.RIGHT);
        else
            button.setHorizontalAlignment(SwingConstants.LEFT);
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