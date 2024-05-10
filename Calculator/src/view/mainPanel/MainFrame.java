package view.mainPanel;

import Listener.ComponentListener;
import Listener.KeypadListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {

    public MainFrame(JPanel panel, ComponentListener componentListener, KeypadListener keypadListener) {
        setLayout(new GridLayout(1, 1));
        add(panel);

        setTitle("계산기");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setMinimumSize(Constants.FRAME_MINI_SIZE);
        setSize(Constants.FRAME_MINI_SIZE);
        setVisible(true);

        addKeyListener(keypadListener);
        addComponentListener(componentListener);
        setFocusable(true);
        requestFocus();
    }
}