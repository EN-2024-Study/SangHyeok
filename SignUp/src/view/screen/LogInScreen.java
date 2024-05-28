package view.screen;

import constant.Enums;
import constant.Texts;
import listener.Controller;
import view.screen.panel.ButtonPanel;
import view.screen.panel.TextFieldPanel;

import javax.swing.*;
import java.awt.*;
import java.util.HashMap;

public class LogInScreen extends JPanel implements IScreen {

    private TextFieldPanel[] textFieldPanel;

    public LogInScreen(Controller controller) {
        setLayout(new GridLayout(2, 1));
        initTextPanel();
        initButtonPanel(controller);
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

    private void initTextPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 1));

        textFieldPanel = new TextFieldPanel[2];
        textFieldPanel[0] = new TextFieldPanel(Texts.ID);
        textFieldPanel[1] = new TextFieldPanel(Texts.PASSWORD);
        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(textFieldPanel[1]);
        add(mainPanel);
    }

    private void initButtonPanel(Controller controller) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 2));

        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.LOGIN, controller), new ButtonPanel(Texts.SIGNUP, controller),
                new ButtonPanel(Texts.FIND_ID, controller), new ButtonPanel(Texts.FIND_PASSWORD, controller)};

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        add(mainPanel);
    }
}
