package form.panel.mainPanel;

import utility.Constants;

import javax.swing.*;
import java.awt.*;
import java.math.BigDecimal;
import java.math.MathContext;

public class SmallNumberPanel extends JPanel {

    protected JLabel numberLabel;

    public SmallNumberPanel() {
        numberLabel = new JLabel(" ");
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

    public void setNumber(String str) {
        numberLabel.setText(str);
    }
}
