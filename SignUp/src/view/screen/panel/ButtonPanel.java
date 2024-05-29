package view.screen.panel;

import listener.Controller;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;

public class ButtonPanel extends JPanel {

    public ButtonPanel(String labelText, ActionListener actionListener) {
        setLayout(new GridLayout(1, 1));
        initButton(labelText, actionListener);
    }

    private void initButton(String labelText, ActionListener actionListener) {
        JButton button = new JButton(labelText);
        button.addActionListener(actionListener);
        add(button);
    }
}
