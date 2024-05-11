package view.mainPanel;

import utility.Constants;

import javax.swing.*;
import java.awt.*;
import java.math.BigDecimal;
import java.text.DecimalFormat;

public class BigNumberPanel extends SmallNumberPanel {

    public BigNumberPanel() {
        super();
        super.numberLabel.setText("0");
        super.numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, Constants.BIG_NUMBER_MAX_SIZE));
    }

    @Override
    public void setNumber(String str) {
        String number = processComma(str);
        numberLabel.setText(number);
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

    private String processComma(String str) {
        String temp = str.replaceAll(",", "");

        if (temp.contains(Constants.POINT_STRING)) {
            String[] number = temp.split("\\.");
            BigDecimal bigDecimal = new BigDecimal(number[0]);
            DecimalFormat decimalFormat = new DecimalFormat("###,###");

            if (number.length == 2)
                return decimalFormat.format(bigDecimal) + Constants.POINT_STRING + number[1];
            return decimalFormat.format(bigDecimal) + Constants.POINT_STRING;
        }

        BigDecimal bigDecimal = new BigDecimal(temp);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        return decimalFormat.format(bigDecimal);
    }

}