package view.MainPanel;

import javax.swing.*;
import java.awt.*;

public class BigNumberPanel extends JPanel {

    private JLabel numberLabel;

    public BigNumberPanel() {
        numberLabel = new JLabel("0");

        Font font = new Font(Font.DIALOG, Font.BOLD, 30);
        numberLabel.setFont(font);
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }
}
