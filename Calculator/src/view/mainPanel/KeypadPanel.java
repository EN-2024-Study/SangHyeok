package view.mainPanel;

import listener.*;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class KeypadPanel extends JPanel {

    private JButton[] buttons;

    public KeypadPanel(KeypadListener keypadListener) {
        setLayout(new GridLayout(5, 4));
        initButton(keypadListener);

        for(JButton button : buttons)
            add(button);
    }

    private void initButton(KeypadListener keypadListener) {
        final Font FONT = new Font(Font.DIALOG, Font.BOLD, 33);
        buttons = new JButton[20];

        for(int i = 0; i < 19; i++) {
            buttons[i] = new JButton(Constants.KEYPAD_STRINGS[i]);
            buttons[i].setFont(FONT);

            buttons[i].addActionListener(keypadListener);
            buttons[i].addKeyListener(keypadListener);
        }

        buttons[19] = new JButton(Constants.KEYPAD_STRINGS[19]);
        buttons[19].setBackground(new Color(0, 103, 192));
        buttons[19].setOpaque(true);
        buttons[19].setBorderPainted(false);
        buttons[19].setForeground(Color.white);
        buttons[19].setFont(FONT);

        buttons[19].addActionListener(keypadListener);
        buttons[19].addKeyListener(keypadListener);
    }

    public JButton[] getButtons() {
        return buttons;
    }
}
