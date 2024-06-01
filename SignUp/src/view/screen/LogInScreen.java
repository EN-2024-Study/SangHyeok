package view.screen;

import constant.Enums;
import constant.Texts;
import view.screen.panel.ButtonPanel;
import view.screen.panel.TextFieldPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class LogInScreen extends JPanel implements ITextField {

    private TextFieldPanel[] textFieldPanel;

    public LogInScreen(ActionListener actionListener) {
        setLayout(null);
        initTextPanel();
        initButtonPanel(actionListener);
    }

    @Override
    public HashMap<Enums.TextType, String> getText() {
        HashMap<Enums.TextType, String> map = new HashMap<>();
        String id = textFieldPanel[0].getText();
        String password = textFieldPanel[1].getText();

        map.put(Enums.TextType.Id, id);
        map.put(Enums.TextType.Password, password);
        return map;
    }

    @Override
    public void resetTextField() {
        for(TextFieldPanel text : textFieldPanel) {
            text.setText("");
        }
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        ImageIcon imageIcon = new ImageIcon(Texts.MAIN_IMAGE);
        g.drawImage(imageIcon.getImage(), 0, 0, getWidth(), getHeight(), null);
    }

    private void initTextPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 1));

        textFieldPanel = new TextFieldPanel[2];
        textFieldPanel[0] = new TextFieldPanel(8, Texts.ID, Texts.ID_PLACEHOLDER,false);
        textFieldPanel[1] = new TextFieldPanel(4, Texts.PASSWORD, Texts.PASSWORD_PLACEHOLDER,true);

        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(textFieldPanel[1]);
        mainPanel.setOpaque(false);
        mainPanel.setBounds(0, 50, 250, 100);

        add(mainPanel);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 2));
        mainPanel.setOpaque(false);

        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.LOGIN, actionListener), new ButtonPanel(Texts.SIGNUP, actionListener),
                new ButtonPanel(Texts.FIND_ID, actionListener), new ButtonPanel(Texts.FIND_PASSWORD, actionListener)};

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        mainPanel.setBounds(250, 50, 250, 100);

        add(mainPanel);
    }
}
