package form.panel;

import listener.ButtonListener;

import javax.swing.*;
import java.awt.*;

public class HistoryButtonPanel extends JPanel {

    private JButton historyButton;

    public HistoryButtonPanel(ButtonListener buttonListener) {
        initHistoryButton(buttonListener);
        initPanel();
    }

    private void initHistoryButton(ButtonListener buttonListener) {
        this.historyButton = new JButton() {
            final Image image = new ImageIcon("etc/HistoryLogo.png").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image, 0, 0, getWidth(), getHeight(), this);
            }
        };

        this.historyButton.setBorderPainted(false);
        this.historyButton.setFocusPainted(false);
        this.historyButton.addActionListener(buttonListener);
    }

    private void initPanel() {
        setBackground(Color.WHITE);
        setLayout(new BorderLayout());
        add(this.historyButton, BorderLayout.EAST);
    }

    public void hideButton() {
        setVisible(false);
    }

    public void showButton() {
        setVisible(true);
    }
}
