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

    public void setFirstDigit(String number) {
        numberLabel.setText(number);
    }

    public void setNumber(String addNumber) {

        if (numberLabel.getText().length() % 3 == 0)
            setComma(addNumber);
        else
            numberLabel.setText(numberLabel.getText() + addNumber);
    }

    private void setComma(String addNumber) {
        StringBuilder resultNumber = new StringBuilder();
        for (int i = 0; i < numberLabel.getText().length(); i++) {
            char c = numberLabel.getText().charAt(i);
            resultNumber.append(c);
            if (i % 3 == 0)
                resultNumber.append(",");
        }
        resultNumber.append(addNumber);

        numberLabel.setText(resultNumber.toString());
    }
}
