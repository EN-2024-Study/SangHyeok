package form.panel.mainPanel;

import listener.ComponentListener;
import listener.KeypadListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {

    public MainFrame(JPanel panel, ComponentListener componentListener, KeypadListener keypadListener) {
        init(panel);
        setListener(componentListener, keypadListener);
    }

    private void init(JPanel panel) {
        setLayout(new GridLayout(1, 1));
        add(panel);

        setTitle("계산기");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setMinimumSize(Constants.FRAME_MINI_SIZE);
        setSize(Constants.FRAME_MINI_SIZE);
        setVisible(true);
    }

    private void setListener(ComponentListener componentListener, KeypadListener keypadListener) {
        addKeyListener(keypadListener);
        addComponentListener(componentListener);
        setFocusable(true);
        requestFocus();
    }
}