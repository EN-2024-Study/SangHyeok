package view;

import observer.ButtonActionListener;
import observer.ButtonMouserListener;

import javax.swing.*;
import java.awt.*;

public class OutputPanel extends JPanel {

    private JLabel numberLabel, buttonLabel, blankLabel;
    private JButton historyButton;

    public OutputPanel() {
        init();
        setPanelByLayout();
    }

    private void init() {
        setBackground(Color.WHITE);

        Font font = new Font(Font.DIALOG, Font.BOLD, 30);
        numberLabel = new JLabel("0");
        blankLabel = new JLabel(" ");
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);
        numberLabel.setFont(font);

        initButtonLabel();
    }

    private void initButtonLabel() {
        buttonLabel = new JLabel();
        buttonLabel.setLayout(new GridLayout(1, 1));

        historyButton = new JButton() {
            final Image image = new ImageIcon("src/view/imageFile/HistoryLogo.jpg").getImage();

            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image, 0, 0, getWidth(), getHeight(), this);
            }
        };

        historyButton.addMouseListener(new ButtonMouserListener());
        buttonLabel.add(historyButton);
    }

    private void setPanelByLayout() {
        setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();

        c.fill = GridBagConstraints.BOTH;
        c.weightx = 1.0;
        c.weighty = 1.0;
        c.gridx = 0;
        c.gridy = 0;
        add(blankLabel, c);

        c.gridx = 1;
        c.gridy = 1;
        add(numberLabel, c);

        c.gridx = 1;
        c.gridy = 0;
        add(buttonLabel, c);
    }
}
