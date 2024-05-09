package view.mainPanel;

import utility.Constants;

import javax.swing.*;
import java.awt.*;
import java.math.BigDecimal;
import java.text.DecimalFormat;

public class BigNumberPanel extends JPanel {

    private JLabel numberLabel;

    public BigNumberPanel() {
        numberLabel = new JLabel("0");

        Font font = new Font(Font.DIALOG, Font.BOLD, 50);
        numberLabel.setFont(font);
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

    public void setNumber(String addNumber) {
        if (numberLabel.getText().equals("0") && !addNumber.equals(Constants.POINT_STRING)) {
            numberLabel.setText(addNumber);
            return;
        } else if (addNumber.equals(Constants.POINT_STRING)) {
            numberLabel.setText(numberLabel.getText() + Constants.POINT_STRING);
            return;
        }

        String labelString = (numberLabel.getText() + addNumber).replaceAll(",", "");
        BigDecimal bigDecimal = new BigDecimal(labelString);
        DecimalFormat decimalFormat = new DecimalFormat("###,###.##");
        numberLabel.setText(decimalFormat.format(bigDecimal));
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
