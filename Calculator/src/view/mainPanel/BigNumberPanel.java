package view.mainPanel;

import javax.swing.*;
import java.awt.*;
import java.text.DecimalFormat;
import java.text.NumberFormat;

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

    public void setNumber(String addNumber) {
        if (numberLabel.getText().equals("0")) {
            numberLabel.setText(addNumber);
            return;
        }

        String labelString = (numberLabel.getText() + addNumber).replaceAll(",", "");
        Long num = Long.parseLong(labelString);
        DecimalFormat decimalFormat = new DecimalFormat("###,###.##");
        numberLabel.setText(decimalFormat.format(num));
    }
}
