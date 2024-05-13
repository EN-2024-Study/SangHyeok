package view.panel.mainPanel;

import utility.Constants;

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
        if (!str.matches(Constants.NUMBER_REGEX))
            return str;

        String num = str.replaceAll(",", "");
        String integerPart = "";
        String decimalPart = "";
        boolean isPoint = false;

        for(int i = 0; i < num.length(); i++) {
            if (num.charAt(i) == '.')
                isPoint = true;

            if (isPoint)
                decimalPart += num.charAt(i);
            else
                integerPart += num.charAt(i);
        }

        BigDecimal bigDecimal = new BigDecimal(integerPart);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        if (isPoint)
            return decimalFormat.format(bigDecimal) + decimalPart;
        return decimalFormat.format(bigDecimal);
    }
}