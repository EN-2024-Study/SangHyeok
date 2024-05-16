package form.panel;

import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class NumberPanel extends JPanel {

    protected JLabel numberLabel;

    public NumberPanel(boolean isBig) {
        initSmallPanel();
        if (isBig) {
            numberLabel.setText("0");
            numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, Constants.BIG_NUMBER_FONT_MAX_SIZE));
        }
    }

    private void initSmallPanel() {
        numberLabel = new JLabel(" ");
        numberLabel.setHorizontalAlignment(JLabel.RIGHT);

        setBackground(Color.WHITE);
        setLayout(new GridLayout(1, 1));
        add(numberLabel);
    }

    public void setNumber(String str) {
        numberLabel.setText(str);
    }

    public void setFont(int frameWidthSize) {
        int fontMaxSize = Constants.BIG_NUMBER_FONT_MAX_SIZE;
        int fontMinSize = Constants.BIG_NUMBER_FONT_MIN_SIZE;

        while (frameWidthSize > numberLabel.getPreferredSize().getWidth() &&
                fontMinSize < fontMaxSize)  // 폰트 사이즈 증가
            numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, ++fontMinSize));

        while (frameWidthSize < numberLabel.getPreferredSize().getWidth()) // 폰트 사이즈 감소
            numberLabel.setFont(new Font(Font.DIALOG, Font.BOLD, --fontMaxSize));
    }
}
