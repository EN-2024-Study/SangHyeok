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
        setLayout(new GridLayout(2, 1));
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

    private void initTextPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 1));

        textFieldPanel = new TextFieldPanel[2];
        textFieldPanel[0] = new TextFieldPanel(14, Texts.ID, false);
        textFieldPanel[1] = new TextFieldPanel(14, Texts.PASSWORD, true);

        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(textFieldPanel[1]);
        add(mainPanel);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 2));

        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.LOGIN, actionListener), new ButtonPanel(Texts.SIGNUP, actionListener),
                new ButtonPanel(Texts.FIND_ID, actionListener), new ButtonPanel(Texts.FIND_PASSWORD, actionListener)};

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        add(mainPanel);
    }
}
