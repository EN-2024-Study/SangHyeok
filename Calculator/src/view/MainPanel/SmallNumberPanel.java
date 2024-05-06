package view.MainPanel;

import javax.swing.*;
import java.awt.*;

public class SmallNumberPanel extends JPanel {

    private JLabel numberLabel;

    public SmallNumberPanel() {
        numberLabel = new JLabel("test");
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

}
