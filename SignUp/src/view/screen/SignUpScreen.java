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

        setLayout(new GridLayout(1, 3));
        initTextPanel(actionListener);
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

    private void initTextPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        JPanel idPanel = getIdFieldPanel(actionListener);
        JPanel emailPanel = getEmailFieldPanel();

        textFieldPanel[0] = new TextFieldPanel(10, Texts.NAME);
        textFieldPanel[2] = new TextFieldPanel(14, Texts.PASSWORD);
        textFieldPanel[3] = new TextFieldPanel(14, Texts.PASSWORD_CHECK);
        textFieldPanel[4] = new TextFieldPanel(8, Texts.BIRTHDAY);
        textFieldPanel[6] = new TextFieldPanel(11, Texts.PHONE_NUMBER);
        textFieldPanel[7] = new TextFieldPanel(100, Texts.ADDRESS);
        textFieldPanel[8] = new TextFieldPanel(100, Texts.DETAILED_ADDRESS);

        mainPanel.setLayout(new GridLayout(9, 1));
        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(idPanel);
        mainPanel.add(textFieldPanel[2]);
        mainPanel.add(textFieldPanel[3]);
        mainPanel.add(textFieldPanel[4]);
        mainPanel.add(emailPanel);
        mainPanel.add(textFieldPanel[6]);
        mainPanel.add(textFieldPanel[7]);
        mainPanel.add(textFieldPanel[8]);

        add(mainPanel);
    }

    private JPanel getIdFieldPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        JPanel buttonPanel = new ButtonPanel(Texts.DUPLICATION_CHECK, actionListener);
        textFieldPanel[1] = new TextFieldPanel(14, Texts.ID);

        mainPanel.setLayout(new GridLayout(1, 2));
        mainPanel.add(textFieldPanel[1]);
        mainPanel.add(buttonPanel);

        return mainPanel;
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
