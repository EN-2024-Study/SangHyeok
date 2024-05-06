package view;

import javax.swing.*;
import java.awt.*;

public class smallNumberPanel extends JPanel {

    private JLabel numberLabel;

    public smallNumberPanel() {
        numberLabel = new JLabel("test");
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

}
