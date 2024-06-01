package view.screen;

import constant.Enums;
import constant.Texts;
import view.screen.panel.ButtonPanel;
import view.screen.panel.TextFieldPanel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class SignUpScreen extends JPanel implements ITextField, IEditor {

    private TextFieldPanel[] textFieldPanel;
    private JComboBox<String> emailAddress;
    private boolean isSignUp;

    public SignUpScreen(ActionListener actionListener, boolean isSignUp) {
        this.isSignUp = isSignUp;
        setLayout(null);
        initTextPanel();
        initButtonPanel(actionListener);
        initEmailComboBox();
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
        textFieldPanel[7].setEditable(true);
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
            textFieldPanel[7].setEditable(false);
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
        textFieldPanel = new TextFieldPanel[9];
        textFieldPanel[0] = new TextFieldPanel(4, Texts.NAME, Texts.NAME_PLACEHOLDER,false);
        textFieldPanel[1] = new TextFieldPanel(8, Texts.ID, Texts.ID_PLACEHOLDER,false);
        textFieldPanel[2] = new TextFieldPanel(4, Texts.PASSWORD, Texts.PASSWORD_PLACEHOLDER,true);
        textFieldPanel[3] = new TextFieldPanel(4, Texts.PASSWORD_CHECK, "", true);
        textFieldPanel[4] = new TextFieldPanel(8, Texts.BIRTHDAY, Texts.BIRTHDAY_PLACEHOLDER,false);
        textFieldPanel[5] = new TextFieldPanel(20, Texts.EMAIL, "", false);
        textFieldPanel[6] = new TextFieldPanel(11, Texts.PHONE_NUMBER, Texts.PHONE_PLACEHOLDER,false);
        textFieldPanel[7] = new TextFieldPanel(100, Texts.ADDRESS, "", false);
        textFieldPanel[8] = new TextFieldPanel(100, Texts.DETAILED_ADDRESS, "", false);

        for(int i = 0, y = 0; i < 9; i++, y += 50) {
            textFieldPanel[i].setBounds(0, y, 300, 50);
        }

        mainPanel.setLayout(null);
        mainPanel.setOpaque(false);
        mainPanel.setBounds(0, 0, 350, 600);

        mainPanel.add(textFieldPanel[0]);
        if (isSignUp) {
            mainPanel.add(textFieldPanel[1]);
        }
        for(int i = 2; i < 9; i++) {
            mainPanel.add(textFieldPanel[i]);
        }

        add(mainPanel);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel[] buttonPanels = null;

        if (isSignUp) {
            buttonPanels = new JPanel[]{new ButtonPanel(Texts.DUPLICATION_CHECK, actionListener), new ButtonPanel(Texts.ADDRESS_CHECK, actionListener),
                   new ButtonPanel(Texts.FIND_ADDRESS, actionListener),  new ButtonPanel(Texts.SIGNUP_CHECK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};
            buttonPanels[0].setBounds(300, 50, 150, 50);
            buttonPanels[1].setBounds(300, 400, 150, 50);
            buttonPanels[2].setBounds(300, 350, 150, 50);
            buttonPanels[3].setBounds(150, 450, 150, 50);
            buttonPanels[4].setBounds(300, 450, 150, 50);
        } else {
            buttonPanels = new JPanel[]{new ButtonPanel(Texts.ADDRESS_CHECK, actionListener), new ButtonPanel(Texts.FIND_ADDRESS, actionListener),
                    new ButtonPanel(Texts.MODIFIED_CHECK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};
            buttonPanels[0].setBounds(300, 400, 150, 50);
            buttonPanels[1].setBounds(300, 350, 150, 50);
            buttonPanels[2].setBounds(150, 450, 150, 50);
            buttonPanels[3].setBounds(300, 450, 150, 50);
        }

        for (JPanel panel : buttonPanels) {
            add(panel);
        }
    }

    private void initEmailComboBox() {
        emailAddress = new JComboBox<>(Texts.EMAIL_COMBOBOX);
        emailAddress.setBounds(300, 130, 200, 300);
        add(emailAddress);
    }
}
