package view;

import constant.Enums;
import constant.Texts;
import listener.Controller;
import observable.IObserver;
import view.screen.*;

import javax.swing.*;
import java.awt.*;
import java.util.HashMap;

public class FrameClient extends JFrame implements IView, IObserver {

    private JPanel[] panelList;

    public FrameClient(Controller controller) {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle(Texts.TITLE);
        setLayout(new BorderLayout());

        this.panelList = new JPanel[] {new FindScreen(controller),
                new HomeScreen(controller), new LogInScreen(controller), new SignUpScreen(controller)};
        showPanel(panelList[2]);

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
    public void update(Object o, String arg) {

    }

    private void showPanel(JPanel panel) {
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
