import javax.swing.*;
import java.awt.*;

public class MainPanel extends JPanel {

    private JFrame frame;
    private String inputString;

    public MainPanel(JFrame frame) {
        this.frame = frame;
        this.inputString = "";
    }

    public JPanel getSearchPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());

        panel.add(getTextField());
        panel.add(getSearchButton());
        panel.add(getHistoryButton());
        return panel;
    }

    public JPanel getSearchedPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());
        panel.add(getTextField());
        panel.add(getSearchButton());
        panel.add(getGoBackButton());
        return panel;
    }

    private JTextField getTextField() {
        JTextField textField = new JTextField(15);
        textField.addActionListener(e -> {
            inputString = textField.getText();
        });
        return textField;
    }

    private JButton getSearchButton() {
        JButton searchButton = new JButton(Constants.BUTTON_SEARCH);
        searchButton.addActionListener(e -> {
            frame.getContentPane().removeAll();
            frame.add(getSearchedPanel());
            frame.revalidate();
            frame.repaint();
        });
        return searchButton;
    }

    private JButton getHistoryButton() {
        JButton historyButton = new JButton(Constants.BUTTON_HISTORY);
//        historyButton.addActionListener(e -> {
//        });
        return historyButton;
    }

    private JButton getGoBackButton() {
        JButton goBackButton = new JButton(Constants.BUTTTON_GOBACK);
        goBackButton.addActionListener(e -> {
            frame.getContentPane().removeAll();
            frame.add(getSearchPanel());
            frame.revalidate();
            frame.repaint();
        });
        return goBackButton;
    }

    public String getInputString() {
        return inputString;
    }
}
