package view.screen;

import constant.Texts;
import view.screen.panel.ButtonPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;

public class HomeScreen extends JPanel{

    public HomeScreen(ActionListener actionListener) {
        setLayout(null);
        initButtonPanel(actionListener);
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        ImageIcon imageIcon = new ImageIcon(Texts.HOME_IMAGE);
        g.drawImage(imageIcon.getImage(), 0, 0, getWidth(), getHeight(), null);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(null);
        mainPanel.setOpaque(false);
        mainPanel.setBounds(300, 200, 300, 300);

        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.ACCOUNT_MODIFY, actionListener),
                new ButtonPanel(Texts.ACCOUNT_DELETE, actionListener), new ButtonPanel(Texts.LOGOUT, actionListener)};
        buttonPanels[0].setBounds(0, 0, 200, 50);
        buttonPanels[1].setBounds(0, 50, 200, 50);
        buttonPanels[2].setBounds(0, 100, 200, 50);

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        add(mainPanel);
    }
}
