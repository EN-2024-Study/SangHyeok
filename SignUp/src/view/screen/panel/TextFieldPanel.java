package view.screen.panel;

import javax.swing.*;
import java.awt.*;

public class TextFieldPanel extends JPanel {

    private JTextField textField;

    public TextFieldPanel(String labelText) {
        init(labelText);
    }

    public String getText() {
        return textField.getText();
    }

    private void init(String labelText) {
        setLayout(new GridLayout(1, 3));

        JLabel label = new JLabel(labelText);
        textField = new JTextField();

        label.setHorizontalAlignment(JLabel.RIGHT);
        add(label);
        add(textField);
    }
}
