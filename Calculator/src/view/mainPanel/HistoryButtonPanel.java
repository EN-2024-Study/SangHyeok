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
        historyButton = new JButton(Constants.HISTORY_BUTTON) {
            final Image IMAGE = new ImageIcon("src/view/imageFile/HistoryLogo.jpg").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(IMAGE, 0, 0, getWidth(), getHeight(), this);
            }
        };
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
