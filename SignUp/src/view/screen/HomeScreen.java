package view.screen;

import constant.Texts;
import listener.Controller;
import view.screen.panel.ButtonPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;

public class HomeScreen extends JPanel{

    public HomeScreen(ActionListener actionListener) {
        setLayout(new GridLayout(1, 1));
        initButtonPanel(actionListener);
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        ImageIcon imageIcon = new ImageIcon("src/images/home_image.jpg");
        g.drawImage(imageIcon.getImage(), 0, 0, getWidth(), getHeight(), null);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(3, 1));

        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.ACCOUNT_MODIFY, actionListener),
                new ButtonPanel(Texts.ACCOUNT_DELETE, actionListener), new ButtonPanel(Texts.LOGOUT, actionListener)};

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        add(mainPanel);
    }
}
