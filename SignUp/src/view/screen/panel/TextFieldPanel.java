package view.screen.panel;

import javax.swing.*;
import java.awt.*;

public class TextFieldPanel extends JPanel {

    private JTextField textField;

    public TextFieldPanel(int maxLength, String labelText, boolean isPassword) {
        init(maxLength, labelText, isPassword);
    }

    public String getText() {
        return textField.getText();
    }

    private void init(int maxLength, String labelText, boolean isPassword) {
        setLayout(new GridLayout(1, 3));

        JLabel label = new JLabel(labelText);
        if (isPassword) {
            textField = new JPasswordField(maxLength);
        } else {
            textField = new JTextField(maxLength);
        }

        label.setHorizontalAlignment(JLabel.RIGHT);
        add(label);
        add(textField);
    }
}
