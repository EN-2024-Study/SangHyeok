package view.LogPanel;

import javax.swing.*;
import java.awt.*;
import java.util.List;

public class ResultScrollPane extends JScrollPane {

    private List<JPanel> smallNumberPanels;
    private List<JPanel> bigNumberPanels;
    private JPanel EarlyPanel;

    public ResultScrollPane() {
        initEarlyPanel();
        add(EarlyPanel);
    }

    private void initEarlyPanel() {
        EarlyPanel = new JPanel();
        JLabel label = new JLabel("아직 기록이 없음");
    }
}
