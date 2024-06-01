package view.screen;

import constant.Enums;
import constant.Texts;
import view.screen.panel.ButtonPanel;
import view.screen.panel.TextFieldPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class AccountFinderScreen extends JPanel implements ITextField {

    private TextFieldPanel[] textFieldPanel;

    public AccountFinderScreen(ActionListener actionListener) {
        setLayout(new GridLayout(2, 1));
        initTextPanel();
        initButtonPanel(actionListener);
    }

    @Override
    public HashMap<Enums.TextType, String> getText() {
        HashMap<Enums.TextType, String> map = new HashMap<>();
        String name = textFieldPanel[0].getText();
        String email = textFieldPanel[1].getText();
        String verificationCode = textFieldPanel[2].getText();

        map.put(Enums.TextType.Name, name);
        map.put(Enums.TextType.Email, email);
        map.put(Enums.TextType.VerificationCode, verificationCode);
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
        mainPanel.setLayout(new GridLayout(3, 1));

        textFieldPanel = new TextFieldPanel[3];
        textFieldPanel[0] = new TextFieldPanel(10, Texts.NAME, false);
        textFieldPanel[1] = new TextFieldPanel(20, Texts.EMAIL, false);
        textFieldPanel[2] = new TextFieldPanel(4, Texts.VERIFICATION_CODE, false);

        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(textFieldPanel[1]);
        mainPanel.add(textFieldPanel[2]);
        add(mainPanel);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        JPanel blankPanel = new JPanel();
        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.GET_CODE, actionListener),
                new ButtonPanel(Texts.OK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};

        blankPanel.add(new JLabel(" "));
        mainPanel.setLayout(new GridLayout(3, 1));
        mainPanel.add(blankPanel);
        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        add(mainPanel);
    }
}
