package view.historyPanel;

import javax.swing.*;
import java.awt.*;

public class RightHistoryPanel extends JPanel {

    private JPanel explainPanel, historyPanel, deletePanel;

    public RightHistoryPanel() {
        setBackground(Color.WHITE);
        initExplainPanel();
        initPanelByLayout();
    }

    private void initExplainPanel() {
        explainPanel = new JPanel();
        explainPanel.setLayout(new GridLayout(3, 1));
        explainPanel.setBackground(Color.WHITE);

        JLabel label1 = new JLabel("기록");
        JLabel label2 = new JLabel(" ");
        JLabel label3 = new JLabel("아직 기록이 없음");

        explainPanel.add(label1);
        explainPanel.add(label2);
        explainPanel.add(label3);
    }

    private void initPanelByLayout() {
        setLayout(new GridLayout(10, 1));
        add(explainPanel);
//        add(resultScrollPanel);
    }
}