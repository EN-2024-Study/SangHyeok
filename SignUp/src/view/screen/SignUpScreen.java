package view.screen;

import constant.Enums;
import constant.Texts;
import view.screen.panel.ButtonPanel;
import view.screen.panel.TextFieldPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class SignUpScreen extends JPanel implements IScreen, ITextFieldSetter {

    private TextFieldPanel[] textFieldPanel;
    private JComboBox<String> emailAddress;
    private boolean isSignUp;

    public SignUpScreen(ActionListener actionListener, boolean isSignUp) {
        this.isSignUp = isSignUp;
        setLayout(new BorderLayout());
        initTextPanel();
        initButtonPanel(actionListener);
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

    @Override
    public void resetTextField() {
        for(TextFieldPanel text : textFieldPanel) {
            text.setText("");
        }
        textFieldPanel[7].setNoEditable(true);
    }

    @Override
    public void setTextField(HashMap<Enums.TextType, String> valueMap) {
        boolean isFindAddress = true;

        if (valueMap.containsKey(Enums.TextType.Name)) {
            isFindAddress = false;
            textFieldPanel[0].setText(valueMap.get(Enums.TextType.Name));
        }
        if (valueMap.containsKey(Enums.TextType.Id)) {
            textFieldPanel[1].setText(valueMap.get(Enums.TextType.Id));
        }
        if (valueMap.containsKey(Enums.TextType.BirthDay)) {
            textFieldPanel[4].setText(valueMap.get(Enums.TextType.BirthDay));
        }
        if (valueMap.containsKey(Enums.TextType.Email)) {
            String email = valueMap.get(Enums.TextType.Email).split(Texts.AT)[0];
            textFieldPanel[5].setText(email);
        }
        if (valueMap.containsKey(Enums.TextType.PhoneNumber)) {
            textFieldPanel[6].setText(valueMap.get(Enums.TextType.PhoneNumber));
        }
        if (valueMap.containsKey(Enums.TextType.Address)) {
            textFieldPanel[7].setText(valueMap.get(Enums.TextType.Address));
        }
        if (valueMap.containsKey(Enums.TextType.DetailedAddress)) {
            textFieldPanel[8].setText(valueMap.get(Enums.TextType.DetailedAddress));
        }

        if (isFindAddress) {
            textFieldPanel[7].setNoEditable(false);
        }
    }

    private void initTextPanel() {
        JPanel mainPanel = new JPanel();

        textFieldPanel = new TextFieldPanel[9];
        textFieldPanel[0] = new TextFieldPanel(4, Texts.NAME, false);
        textFieldPanel[1] = new TextFieldPanel(8, Texts.ID, false);
        textFieldPanel[2] = new TextFieldPanel(4, Texts.PASSWORD, true);
        textFieldPanel[3] = new TextFieldPanel(4, Texts.PASSWORD_CHECK, true);
        textFieldPanel[4] = new TextFieldPanel(8, Texts.BIRTHDAY, false);
        textFieldPanel[5] = new TextFieldPanel(20, Texts.EMAIL, false);
        textFieldPanel[6] = new TextFieldPanel(11, Texts.PHONE_NUMBER, false);
        textFieldPanel[7] = new TextFieldPanel(100, Texts.ADDRESS, false);
        textFieldPanel[8] = new TextFieldPanel(100, Texts.DETAILED_ADDRESS, false);

        mainPanel.setLayout(new GridLayout(9, 1));
        mainPanel.add(textFieldPanel[0]);
        if (isSignUp) {
            mainPanel.add(textFieldPanel[1]);
        }
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
        JPanel[] buttonPanels = null;

        if (isSignUp) {
            buttonPanels = new JPanel[]{new ButtonPanel(Texts.DUPLICATION_CHECK, actionListener), new ButtonPanel(Texts.ADDRESS_CHECK, actionListener),
                    new ButtonPanel(Texts.SIGNUP_CHECK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};
        } else {
            buttonPanels = new JPanel[]{new ButtonPanel(Texts.ADDRESS_CHECK, actionListener),
                    new ButtonPanel(Texts.MODIFIED_CHECK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};
        }

        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }

        add(mainPanel, BorderLayout.SOUTH);
    }

    private JPanel getEmailFieldPanel() {
        JPanel mainPanel = new JPanel();
        JLabel at = new JLabel(Texts.AT);
        emailAddress = new JComboBox<>(Texts.EMAIL_COMBOBOX);

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
