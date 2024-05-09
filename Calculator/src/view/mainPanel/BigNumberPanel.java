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

        numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, Constants.BIG_NUMBER_MAX_SIZE));
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

    public void setNumber(String addString) {
        if (numberLabel.getText().equals("0")) { // 처음 문자가 들어왔을 때

            if (addString.equals(Constants.POINT_STRING)) { // 첫 문자가 소수점이라면 소수점 삽입
                numberLabel.setText("0" + addString);
                return;
            }
            for (String n : Constants.NUMBER_STRINGS) {
                if (n.equals(addString)) {    // 첫 문자가 숫자라면 그대로 삽입
                    numberLabel.setText(addString);
                }
            }
        } else if (numberLabel.getText().contains(Constants.POINT_STRING))    // 소수점이 이미 들어와있을 때
            numberLabel.setText(numberLabel.getText() + addString);

        else if (addString.equals(Constants.POINT_STRING))  // 소수점이 처음 들어왔을 때 삽입
            numberLabel.setText(numberLabel.getText() + addString);
        else
            processComma(addString);    // 컴마 처리
    }

    private void processComma(String addNumber) {
        String labelString = (numberLabel.getText() + addNumber).replaceAll(",", "");
        BigDecimal bigDecimal = new BigDecimal(labelString);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
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
        for (int i = 0; i < numberLabel.getText().length() - 2; i++)
            result.append(numberLabel.getText().charAt(i));

        if (numberLabel.getText().charAt(numberLabel.getText().length() - 2) != ',')
            result.append(numberLabel.getText().charAt(numberLabel.getText().length() - 2));

        numberLabel.setText(result.toString());
    }

    public JLabel getNumberLabel() {
        return numberLabel;
    }
}
