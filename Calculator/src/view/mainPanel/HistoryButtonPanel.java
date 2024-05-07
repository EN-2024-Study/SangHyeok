package view.mainPanel;

import observer.ButtonActionListener;

import javax.swing.*;
import java.awt.*;

public class HistoryButtonPanel extends JPanel {

    private JButton historyButton;

    public HistoryButtonPanel() {
        initHistoryButton();
        setBackground(Color.WHITE);
        setPanelByLayout();
    }

    private void initHistoryButton() {
        historyButton = new JButton("history") {
            final Image IMAGE = new ImageIcon("src/view/imageFile/HistoryLogo.jpg").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(IMAGE, 0, 0, getWidth(), getHeight(), this);
            }
        };

        historyButton.addActionListener(new ButtonActionListener());
    }

    private void setPanelByLayout() {
        setLayout(new BorderLayout());
        add(historyButton, BorderLayout.EAST);
    }

    public void hideButton() {
        setVisible(false);
    }

    public void showButton() {
        setVisible(true);
    }
}
