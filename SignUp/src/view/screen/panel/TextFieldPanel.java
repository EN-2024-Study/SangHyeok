package view.screen.panel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class TextFieldPanel extends JPanel {

    private JTextField textField;
    private final String placeholder;

    public TextFieldPanel(int maxLength, String labelText, String placeholder, boolean isPassword) {
        this.placeholder = placeholder;
        init(maxLength, labelText, isPassword);
    }

    public String getText() {
        return textField.getText();
    }

    public void setText(String text) {
        textField.setText(text);
    }

    public void setEditable(boolean isNoEditable) {
        textField.setEnabled(isNoEditable);
    }

    private void init(int maxLength, String labelText, boolean isPassword) {
        setLayout(new GridLayout(1, 3));
        setOpaque(false);

        JLabel label = new JLabel(labelText);
        label.setHorizontalAlignment(JLabel.RIGHT);

        initTextField(maxLength, isPassword);
        add(label);
        add(textField);
    }

    private void initTextField(int maxLength, boolean isPassword) {
        if (isPassword) {
            textField = new JPasswordField() {
                @Override
                public void paintComponent(Graphics g) {
                    super.paintComponent(g);
                    printPlaceholder(g);
                }
            };
        } else {
            textField = new JTextField() {
                @Override
                public void paintComponent(Graphics g) {
                    super.paintComponent(g);
                    printPlaceholder(g);
                }
            };
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

    private void printPlaceholder(Graphics g) {
        if (!getText().isEmpty() || isFocusOwner()) {
            return;
        }

        Graphics2D g2 = (Graphics2D) g;
        g2.setColor(Color.GRAY);

        if (placeholder == null) {
            return;
        }
        g2.drawString(placeholder, getInsets().left, g.getFontMetrics().getMaxAscent() + getInsets().top);
    }
}
