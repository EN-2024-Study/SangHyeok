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
        if (numberLabel.getText().equals("0") && !addNumber.equals(Constants.POINT_STRING))
            numberLabel.setText(addNumber);
         else if (addNumber.equals(Constants.POINT_STRING))
            numberLabel.setText(numberLabel.getText() + Constants.POINT_STRING);
         else if (hasPoint())
            numberLabel.setText(numberLabel.getText() + addNumber);
         else
            processComma(addNumber);
    }

    private void processComma(String addNumber) {
        String labelString = (numberLabel.getText() + addNumber).replaceAll(",", "");
        BigDecimal bigDecimal = new BigDecimal(labelString);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        numberLabel.setText(decimalFormat.format(bigDecimal));
    }

    private boolean hasPoint() {
        for (int i = 0; i < numberLabel.getText().length(); i++)
            if (numberLabel.getText().charAt(i) == Constants.POINT_STRING.charAt(0))
                return true;
        return false;
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
        for (int i = 0; i < numberLabel.getText().length() - 2; i++)
            result.append(numberLabel.getText().charAt(i));

        if (numberLabel.getText().charAt(numberLabel.getText().length() - 2) != ',')
            result.append(numberLabel.getText().charAt(numberLabel.getText().length() - 2));

        numberLabel.setText(result.toString());
    }
}
