package view;

import constant.Enums;
import constant.Texts;
import view.screen.*;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class FrameClient extends JFrame implements IView {

    private JPanel[] panelList;

    public FrameClient(ActionListener actionListener) {
        this.panelList = new JPanel[] {new FindScreen(actionListener),
                new HomeScreen(actionListener), new LogInScreen(actionListener), new SignUpScreen(actionListener)};

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle(Texts.TITLE);
        setLayout(new BorderLayout());

        showScreen(Enums.ScreenType.LogIn);
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
    public void showScreen(Enums.ScreenType screenType) {
        for(JPanel p : panelList) {
            remove(p);
        }

        add(getBlankPanel(), BorderLayout.SOUTH);
        add(getBlankPanel(), BorderLayout.NORTH);
        add(getBlankPanel(), BorderLayout.EAST);
        add(getBlankPanel(), BorderLayout.WEST);

        switch(screenType) {
            case Find -> add(panelList[0], BorderLayout.CENTER);
            case Home -> add(panelList[1], BorderLayout.CENTER);
            case LogIn -> add(panelList[2], BorderLayout.CENTER);
            case SignUp -> add(panelList[3], BorderLayout.CENTER);
        }

        restartFrame();
    }

    @Override
    public void showDialog(boolean isComplete, String text) {
        JDialog dialog = new JDialog(this, true);
        JLabel label = new JLabel(text);

        label.setHorizontalAlignment(JLabel.CENTER);
        if (isComplete) {
            dialog.setTitle(Texts.COMPLETE);
        } else {
            dialog.setTitle(Texts.ERROR);
        }
        dialog.setSize(300, 100);
        dialog.add(label);
        dialog.setLocationRelativeTo(this);
        dialog.setVisible(true);

        restartFrame();
    }

    private JPanel getBlankPanel() {
        JPanel panel = new JPanel();
        panel.setPreferredSize(new Dimension(100, 100));
        return panel;
    }

    private void restartFrame() {
        revalidate();
        repaint();
    }
}
