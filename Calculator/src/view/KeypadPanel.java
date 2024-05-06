package view;

import Observer.ButtonActionListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class KeypadPanel extends JPanel {

    private JButton[] buttons;
    private ButtonActionListener buttonActionListener;

    public KeypadPanel() {
        setLayout(new GridLayout(5, 4));
        initButton();
        setPanelByButton();
    }

    private void initButton() {
        buttonActionListener = new ButtonActionListener();
        buttons = new JButton[20];

        Font font = new Font(Font.DIALOG, Font.BOLD, 36);

        for(int i = 0; i < 20; i++) {
            buttons[i] = new JButton(Constants.BUTTON_STRINGS[i]);
            buttons[i].setFont(font);
            buttons[i].addActionListener(buttonActionListener);
        }
    }

    private void setPanelByButton() {
        for(JButton button : buttons)
            add(button);
    }
}
