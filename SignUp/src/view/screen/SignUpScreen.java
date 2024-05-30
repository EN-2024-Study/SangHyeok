package view.screen;

import constant.Enums;
import constant.Texts;
import listener.Controller;
import view.screen.panel.ButtonPanel;
import view.screen.panel.TextFieldPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class SignUpScreen extends JPanel implements IScreen {

    private TextFieldPanel[] textFieldPanel;
    private JComboBox<String> emailAddress;

    public SignUpScreen(ActionListener actionListener) {
        textFieldPanel = new TextFieldPanel[9];
        initScreen(actionListener);
    }

    @Override
    public HashMap<Enums.TextType, String> getText() {
        HashMap<Enums.TextType, String> map = new HashMap<>();

        map.put(Enums.TextType.Name, textFieldPanel[0].getText());
        map.put(Enums.TextType.Id, textFieldPanel[1].getText());
        map.put(Enums.TextType.Password, textFieldPanel[2].getText());
        map.put(Enums.TextType.PasswordCheck, textFieldPanel[3].getText());
        map.put(Enums.TextType.BirthDay, textFieldPanel[4].getText());
        map.put(Enums.TextType.Email, textFieldPanel[5].getText() + Texts.AT + emailAddress.getSelectedItem().toString());
        map.put(Enums.TextType.PhoneNumber, textFieldPanel[6].getText());
        map.put(Enums.TextType.Address, textFieldPanel[7].getText());
        map.put(Enums.TextType.DetailedAddress, textFieldPanel[8].getText());
        return map;
    }

    private void initScreen(ActionListener actionListener) {
        setLayout(new BorderLayout());
        initTextPanel();
        initButtonPanel(actionListener);
    }

    private void initTextPanel() {
        JPanel mainPanel = new JPanel();

        textFieldPanel[0] = new TextFieldPanel(10, Texts.NAME);
        textFieldPanel[1] = new TextFieldPanel(14, Texts.ID);
        textFieldPanel[2] = new TextFieldPanel(14, Texts.PASSWORD);
        textFieldPanel[3] = new TextFieldPanel(14, Texts.PASSWORD_CHECK);
        textFieldPanel[4] = new TextFieldPanel(8, Texts.BIRTHDAY);
        textFieldPanel[6] = new TextFieldPanel(11, Texts.PHONE_NUMBER);
        textFieldPanel[7] = new TextFieldPanel(100, Texts.ADDRESS);
        textFieldPanel[8] = new TextFieldPanel(100, Texts.DETAILED_ADDRESS);

        mainPanel.setLayout(new GridLayout(9, 1));
        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(textFieldPanel[1]);
        mainPanel.add(textFieldPanel[2]);
        mainPanel.add(textFieldPanel[3]);
        mainPanel.add(textFieldPanel[4]);
        mainPanel.add(getEmailFieldPanel());
        mainPanel.add(textFieldPanel[6]);
        mainPanel.add(textFieldPanel[7]);
        mainPanel.add(textFieldPanel[8]);

        add(mainPanel, BorderLayout.CENTER);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(2, 2));

        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.DUPLICATION_CHECK, actionListener), new ButtonPanel(Texts.FIND_ADDRESS, actionListener),
                new ButtonPanel(Texts.SIGNUP_CHECK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }

        add(mainPanel, BorderLayout.SOUTH);
    }

    private JPanel getEmailFieldPanel() {
        JPanel mainPanel = new JPanel();
        JLabel at = new JLabel(Texts.AT);
        emailAddress = new JComboBox<>(Texts.EMAIL_COMBOBOX);
        textFieldPanel[5] = new TextFieldPanel(20, Texts.EMAIL);

        mainPanel.setLayout(new GridBagLayout());
        GridBagConstraints constraints = new GridBagConstraints();
        constraints.gridx = 0;
        constraints.gridy = 0;
        constraints.weightx = 1;
        constraints.weighty = 1;
        constraints.fill = GridBagConstraints.HORIZONTAL;
        mainPanel.add(textFieldPanel[5], constraints);

        constraints.gridx = 1;
        constraints.weightx = 0.1;
        mainPanel.add(at);

        constraints.gridx = 2;
        constraints.weightx = 0.7;
        mainPanel.add(emailAddress, constraints);

        return mainPanel;
    }
}
