package view.screen.panel;

import controller.Listener;

import javax.swing.*;
import java.awt.*;

public class ButtonPanel extends JPanel {

    public ButtonPanel(String labelText, Listener listener) {
        setLayout(new GridLayout(1, 1));
        initButton(labelText, listener);
    }

    private void initButton(String labelText, Listener listener) {
        JButton button = new JButton(labelText);
        button.addActionListener(listener);
        add(button);
    }
}
