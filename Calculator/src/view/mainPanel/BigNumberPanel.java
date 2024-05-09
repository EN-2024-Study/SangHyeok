package view.mainPanel;

import javax.swing.*;
import java.awt.*;
import java.text.DecimalFormat;

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

    public void resetNumber() {
        numberLabel.setText("0");
    }

    public void deleteNumber() {
        if (numberLabel.getText().length() == 1) {
            numberLabel.setText("0");
            return;
        }

        StringBuilder result = new StringBuilder();
        for(int i = 0; i < numberLabel.getText().length() - 2; i++)
            result.append(numberLabel.getText().charAt(i));

        if (numberLabel.getText().charAt(numberLabel.getText().length() - 2) != ',')
            result.append(numberLabel.getText().charAt(numberLabel.getText().length() - 2));

        numberLabel.setText(result.toString());
    }
}
