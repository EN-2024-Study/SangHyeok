package view;

import javax.swing.*;
import java.awt.*;

public class OutputPanel extends JPanel {

    private JLabel numberLabel, explainLabel;
    private JButton historyButton;

    public OutputPanel() {
        init();
        setLabelByFont();
        setPanelByLayout();
    }

    private void init() {
        numberLabel = new JLabel("test");
        explainLabel = new JLabel("표준");
        historyButton = new JButton() {
            ImageIcon imageIcon = new ImageIcon("src/view/HistoryLogo.jpg");
            final Image image = imageIcon.getImage();
            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image, 0, 0, getWidth(), getHeight(), this);
            }
        };
    }

    private void setLabelByFont() {
        Font font = new Font(Font.DIALOG, Font.BOLD, 30);
        numberLabel.setFont(font);
        explainLabel.setFont(font);
        historyButton.setFont(font);
    }

    private void setPanelByLayout() {
        setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();
        c.gridx = 0;
        c.gridy = 0;
        c.gridwidth = 1;
        c.weightx = 0.5;
        c.weighty = 0.1;
        c.fill = GridBagConstraints.BOTH;
        add(explainLabel, c);

        c.gridx = 1;
        c.weightx = 0.05;
        add(historyButton, c);

        c.gridy = 1;
        c.weighty = 0.6;
        add(numberLabel, c);
    }
}
