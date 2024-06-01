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
        setLayout(null);
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

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        ImageIcon imageIcon = new ImageIcon(Texts.MAIN_IMAGE);
        g.drawImage(imageIcon.getImage(), 0, 0, getWidth(), getHeight(), null);
    }

    private void initTextPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridLayout(3, 1));
        mainPanel.setOpaque(false);

        textFieldPanel = new TextFieldPanel[3];
        textFieldPanel[0] = new TextFieldPanel(10, Texts.NAME, Texts.NAME_PLACEHOLDER, false);
        textFieldPanel[1] = new TextFieldPanel(20, Texts.EMAIL, "",false);
        textFieldPanel[2] = new TextFieldPanel(4, Texts.VERIFICATION_CODE, "", false);

        mainPanel.add(textFieldPanel[0]);
        mainPanel.add(textFieldPanel[1]);
        mainPanel.add(textFieldPanel[2]);
        mainPanel.setBounds(0, 0, 350, 150);
        add(mainPanel);
    }

    private void initButtonPanel(ActionListener actionListener) {
        JPanel mainPanel = new JPanel();
        JPanel blankPanel = new JPanel();
        JPanel[] buttonPanels = new JPanel[]{new ButtonPanel(Texts.GET_CODE, actionListener),
                new ButtonPanel(Texts.OK, actionListener), new ButtonPanel(Texts.GO_BACK, actionListener)};

        blankPanel.add(new JLabel(" "));
        blankPanel.setOpaque(false);

        mainPanel.setLayout(null);
        mainPanel.setOpaque(false);

        buttonPanels[0].setBounds(0, 50, 100, 50);
        buttonPanels[1].setBounds(0, 0, 100, 50);
        buttonPanels[2].setBounds(0, 100, 100, 50);

        mainPanel.add(blankPanel);
        for (JPanel panel : buttonPanels) {
            mainPanel.add(panel);
        }
        mainPanel.setBounds(350, 0, 300, 150);

        add(mainPanel);
    }
}
