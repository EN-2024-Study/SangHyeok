package view.mainPanel;

import javax.swing.*;
import java.awt.*;

public class BigNumberPanel extends JPanel {

    private JLabel numberLabel;

    public BigNumberPanel() {
        numberLabel = new JLabel("0");

        Font font = new Font(Font.DIALOG, Font.BOLD, 60);
        numberLabel.setFont(font);
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new FlowLayout(FlowLayout.RIGHT));
        add(numberLabel);
    }

    public void setNumber(boolean isFirst, String number) {
        if (isFirst)
            numberLabel.setText(number);
        else
            numberLabel.setText(numberLabel.getText() + number);
    }
}
