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

    public void setNumber(String number) {
        numberLabel.setText(number);
    }

    public void resetNumber() {
        numberLabel.setText("0");
    }

    public void setFont(int frameWidthSize) {
        int fontMaxSize = Constants.BIG_NUMBER_MAX_SIZE;
        int fontMinSize = Constants.BIG_NUMBER_MIN_SIZE;

        while(frameWidthSize > numberLabel.getPreferredSize().getWidth() &&
                fontMinSize < fontMaxSize)  // 폰트 사이즈 증가
            numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, ++fontMinSize));

        while(frameWidthSize < numberLabel.getPreferredSize().getWidth()) // 폰트 사이즈 감소
            numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, --fontMaxSize));
    }
}