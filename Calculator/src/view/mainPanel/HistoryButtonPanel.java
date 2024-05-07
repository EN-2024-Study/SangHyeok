package view.mainPanel;

import model.ListenerVo;
import observer.ButtonActionListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class HistoryButtonPanel extends JPanel {

    private JButton historyButton;

    public HistoryButtonPanel(ButtonActionListener buttonActionListener) {
        initHistoryButton(buttonActionListener);
        initPanel();
    }

    private void initHistoryButton(ButtonActionListener buttonActionListener) {
        historyButton = new JButton() {
            Image image = new ImageIcon("src/view/imageFile/HistoryLogo.png").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image, 0, 0, getWidth(), getHeight(), this);
            }
        };

        historyButton.setBorderPainted(false);
        historyButton.setFocusPainted(false);
        historyButton.addActionListener(buttonActionListener);
    }

    private void initPanel() {
        setBackground(Color.WHITE);
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
