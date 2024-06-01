package view.screen.panel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class TextFieldPanel extends JPanel {

    private JTextField textField;

    public TextFieldPanel(int maxLength, String labelText, boolean isPassword) {
        init(maxLength, labelText, isPassword);
    }

    public String getText() {
        return textField.getText();
    }

    public void setText(String text) {
        textField.setText(text);
    }

    public void setNoEditable() {
        textField.setEnabled(false);
    }

    private void init(int maxLength, String labelText, boolean isPassword) {
        setLayout(new GridLayout(1, 3));

        JLabel label = new JLabel(labelText);
        label.setHorizontalAlignment(JLabel.RIGHT);

        initTextField(maxLength, isPassword);
        add(label);
        add(textField);
    }

    private void initTextField(int maxLength, boolean isPassword) {
        if (isPassword) {
            textField = new JPasswordField();
        } else {
            textField = new JTextField();
        }

        //===== 입력 길이 제한 =====//
        textField.addKeyListener(new KeyAdapter() {
            @Override
            public void keyTyped(KeyEvent e) {
                JTextField textField = (JTextField) e.getSource();
                if (textField.getText().length() >= maxLength) {
                    e.consume();
                }
            }
        });
    }
}
