package view.screen.panel;

import listener.Controller;

import javax.swing.*;
import java.awt.*;

public class ButtonPanel extends JPanel {

    public ButtonPanel(String labelText, Controller controller) {
        setLayout(new GridLayout(1, 1));
        initButton(labelText, controller);
    }

    private void initButton(String labelText, Controller controller) {
        JButton button = new JButton(labelText);
        button.addActionListener(controller);
        add(button);
    }
}
