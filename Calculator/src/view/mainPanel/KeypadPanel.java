package view.mainPanel;

import observer.*;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class KeypadPanel extends JPanel {

    private JButton[] buttons;
    private ButtonActionListener buttonActionListener;

    public KeypadPanel() {
        setLayout(new GridLayout(5, 4));
        initButton();

        for(JButton button : buttons)
            add(button);
    }

    private void initButton() {
        final Font FONT = new Font(Font.DIALOG, Font.BOLD, 36);
        buttonActionListener = new ButtonActionListener();
        buttons = new JButton[20];

        for(int i = 0; i < 19; i++) {
            buttons[i] = new JButton(Constants.BUTTON_STRINGS[i]);
            buttons[i].setFont(FONT);
            buttons[i].addActionListener(buttonActionListener);
        }

        buttons[19] = new JButton(Constants.BUTTON_STRINGS[19]);
        buttons[19].setBackground(new Color(0, 103, 192));
        buttons[19].setOpaque(true);
        buttons[19].setBorderPainted(false);

        buttons[19].setForeground(Color.white);
        buttons[19].setFont(FONT);
        buttons[19].addActionListener(buttonActionListener);
    }
}
