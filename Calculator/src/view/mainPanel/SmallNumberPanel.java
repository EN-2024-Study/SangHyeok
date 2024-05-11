package view.mainPanel;

import javax.swing.*;
import java.awt.*;

public class SmallNumberPanel extends JPanel {

    protected JLabel numberLabel;

    public SmallNumberPanel() {
        numberLabel = new JLabel("");
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

    public void setNumber(String number) {
        numberLabel.setText(number);
    }
}
