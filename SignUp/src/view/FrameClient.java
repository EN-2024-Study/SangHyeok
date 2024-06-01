package view;

import constant.DialogTexts;
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
        this.panelList = new JPanel[]{new FindScreen(actionListener),
                new HomeScreen(actionListener), new LogInScreen(actionListener),
                new SignUpScreen(actionListener, true), new SignUpScreen(actionListener, false)};

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle(Texts.TITLE);
        setLayout(new BorderLayout());

        setSize(600, 600);
        setVisible(true);
    }

    @Override
    public HashMap<Enums.TextType, String> getText(Enums.ScreenType screenType) {
        switch (screenType) {
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
            case Modify -> {
                IScreen screen = (IScreen) panelList[4];
                return screen.getText();
            }
        }
        return null;
    }

    @Override
    public void showScreen(Enums.ScreenType screenType) {
        switch (screenType) {
            case Find -> show(panelList[0]);
            case Home -> show(panelList[1]);
            case LogIn -> show(panelList[2]);
            case SignUp -> show(panelList[3]);
            case Modify -> show(panelList[4]);
        }

        restartFrame();
    }

    @Override
    public void showDialog(boolean isComplete, String text) {
        JDialog dialog = new JDialog(this, true);
        JLabel label = new JLabel(text);

        label.setHorizontalAlignment(JLabel.CENTER);
        if (isComplete) {
            dialog.setTitle(DialogTexts.COMPLETE);
        } else {
            dialog.setTitle(DialogTexts.FAIL);
        }
        dialog.setSize(300, 100);
        dialog.add(label);
        dialog.setLocationRelativeTo(this);
        dialog.setVisible(true);

        restartFrame();
    }

    @Override
    public void setTextField(Enums.ScreenType screenType, HashMap<Enums.TextType, String> valueMap) {
        ITextFieldSetter textFieldSetter = null;
        switch (screenType) {
            case SignUp -> textFieldSetter = (ITextFieldSetter) panelList[3];
            case Modify -> textFieldSetter = (ITextFieldSetter) panelList[4];
        }

        textFieldSetter.setTextField(valueMap);
    }

    private void show(JPanel panel) {
        for (JPanel p : panelList) {
            remove(p);
        }

        if (panel instanceof IScreen) {
            ((IScreen) panel).resetTextField();
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

    private void restartFrame() {
        revalidate();
        repaint();
    }
}
