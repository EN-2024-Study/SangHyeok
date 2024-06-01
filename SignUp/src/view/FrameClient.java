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
        this.panelList = new JPanel[]{new AccountFinderScreen(actionListener),
                new HomeScreen(actionListener), new LogInScreen(actionListener),
                new SignUpScreen(actionListener, true), new SignUpScreen(actionListener, false)};

        initFrame();
    }

    @Override
    public HashMap<Enums.TextType, String> getText(Enums.ScreenType screenType) {
        switch (screenType) {
            case Find -> {
                ITextField screen = (ITextField) panelList[0];
                return screen.getText();
            }
            case LogIn -> {
                ITextField screen = (ITextField) panelList[2];
                return screen.getText();
            }
            case SignUp -> {
                ITextField screen = (ITextField) panelList[3];
                return screen.getText();
            }
            case Modify -> {
                ITextField screen = (ITextField) panelList[4];
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
        IEditor iEditor = null;
        switch (screenType) {
            case SignUp -> iEditor = (IEditor) panelList[3];
            case Modify -> iEditor = (IEditor) panelList[4];
        }

        iEditor.setTextField(valueMap);
    }

    private void show(JPanel panel) {
        for (JPanel p : panelList) {
            remove(p);
        }

        if (panel instanceof ITextField) {
            ((ITextField) panel).resetTextField();
        }
        add(panel);
    }

    private void initFrame() {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle(Texts.TITLE);
        setLayout(new GridLayout(1, 1));

        setResizable(false);
        setSize(600, 600);
        setVisible(true);
    }

    private void restartFrame() {
        revalidate();
        repaint();
    }
}
