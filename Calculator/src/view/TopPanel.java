package view;

import javax.swing.*;
import java.awt.*;

public class TopPanel extends JPanel {

    private JButton historyButton;

    public TopPanel() {
        historyButton = new JButton() {
            final Image image = new ImageIcon("src/view/imageFile/HistoryLogo.jpg").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image, 0, 0, getWidth(), getHeight(), this);
            }
        };

        historyButton.setBackground(Color.RED);

        setBackground(Color.WHITE);
        setLayout(new FlowLayout(FlowLayout.RIGHT));
        add(historyButton);
    }
}
