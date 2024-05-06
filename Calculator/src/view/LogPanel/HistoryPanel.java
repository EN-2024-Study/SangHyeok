package view.LogPanel;

import javax.swing.*;
import java.awt.*;

public class HistoryPanel extends JPanel {

    private JPanel explainPanel;
    private ResultScrollPane resultScrollPane;

    public HistoryPanel() {
        setLayout(new BorderLayout());

        initExplainPanel();
        resultScrollPane = new ResultScrollPane();

        add(explainPanel, BorderLayout.NORTH);
        add(resultScrollPane, BorderLayout.CENTER);
    }

    private void initExplainPanel() {
        explainPanel = new JPanel();
        explainPanel.setLayout(new GridLayout(1, 1));
        JLabel textLabel = new JLabel("기록");
        textLabel.setHorizontalAlignment(JLabel.CENTER);
    }
}
