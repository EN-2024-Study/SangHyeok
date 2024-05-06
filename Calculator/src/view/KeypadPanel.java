package view;

import Observer.NumberButtonActionListener;

import javax.swing.*;
import java.awt.*;

public class KeypadPanel extends JPanel {

    private JButton[] buttons;
    private NumberButtonActionListener numberButtonActionListener;

    public KeypadPanel() {
        setLayout(new GridLayout(5, 4));
        initButton();
        setPanelByButton();
    }

    private void initButton() {
        numberButtonActionListener = new NumberButtonActionListener();
        buttons = new JButton[20];

        Font font = new Font(Font.DIALOG, Font.BOLD, 36);
        String[] buttonStrings = new String[] {"/", "CE", "C", "<", "7", "8", "9", "X", "4", "5", "6", "-", "1", "2", "3", "+", "+/-", "0", ".", "="};

        for(int i = 0; i < 20; i++) {
            buttons[i] = new JButton(buttonStrings[i]);
            buttons[i].setFont(font);
            buttons[i].addActionListener(numberButtonActionListener);
        }
    }

    private void setPanelByButton() {
        for(JButton button : buttons)
            add(button);
    }
}
