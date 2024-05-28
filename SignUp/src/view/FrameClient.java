package view;

import constant.Enums;
import constant.Texts;
import controller.Listener;
import view.screen.*;

import javax.swing.*;
import java.awt.*;
import java.util.HashMap;

public class FrameClient extends JFrame implements IView {

    private JPanel[] panelList;

    public FrameClient(Listener listener) {
        this.panelList = new JPanel[] {new FindScreen(listener),
                new HomeScreen(listener), new LogInScreen(listener), new SignUpScreen(listener)};

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle(Texts.TITLE);
        setLayout(new BorderLayout());

        showScreen(panelList[2]);
        setSize(600, 600);
        setVisible(true);
    }

    @Override
    public HashMap<Enums.TextType, String> getText(Enums.ScreenType screenType) {
        switch(screenType) {
            case Find -> {
                IScreen screen = (IScreen) panelList[0];
                return screen.getText();
            }
            case LogIn -> {
                IScreen screen = (IScreen) panelList[2];
                return screen.getText();
            }
            case SignUp -> {
                IScreen screen = (IScreen) panelList[3];
                return screen.getText();
            }
        }
        return null;
    }

    @Override
    public void showScreen(JPanel panel) {
        for(JPanel p : panelList) {
            remove(p);
        }

        add(getBlankPanel(), BorderLayout.SOUTH);
        add(getBlankPanel(), BorderLayout.NORTH);
        add(getBlankPanel(), BorderLayout.EAST);
        add(getBlankPanel(), BorderLayout.WEST);
        add(panel, BorderLayout.CENTER);
    }

    private JPanel getBlankPanel() {
        JPanel panel = new JPanel();
        panel.setPreferredSize(new Dimension(100, 100));
        return panel;
    }
}
