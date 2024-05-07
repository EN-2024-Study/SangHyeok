package view.mainPanel;

import observer.ButtonActionListener;

import javax.swing.*;
import java.awt.*;

public class HistoryButtonPanel extends JPanel {

    private JButton historyButton;

    public HistoryButtonPanel() {
        historyButton = new JButton() {
            final Image IMAGE = new ImageIcon("src/view/imageFile/HistoryLogo.jpg").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(IMAGE, 0, 0, getWidth(), getHeight(), this);
            }
        };

        historyButton.setBackground(Color.RED);
        historyButton.addActionListener(new ButtonActionListener());
        setBackground(Color.WHITE);
        setLayout(new FlowLayout(FlowLayout.RIGHT));
        add(historyButton);
    }

    public void hideButton() {
        setVisible(false);
    }

    public void showButton() {
        setVisible(true);
    }
}
