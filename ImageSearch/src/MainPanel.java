import javax.swing.*;
import java.awt.*;

public class MainPanel extends JPanel {

    public JPanel getSearchPanel() {
        JPanel searchPanel = new JPanel();
        searchPanel.setLayout(new FlowLayout());
        searchPanel.add(getTextField());
        searchPanel.add(getSearchButton());
        searchPanel.add(getHistoryButton());
        return searchPanel;
    }

    public JPanel getSearchedPanel() {
        JPanel searchedPanel = new JPanel();
        searchedPanel.setLayout(new FlowLayout());
        searchedPanel.add(getTextField());
        searchedPanel.add(getSearchButton());
        searchedPanel.add(getHistoryButton());
        return searchedPanel;
    }

    private JTextField getTextField() {
        JTextField textField = new JTextField(15);
        textField.addActionListener(e -> {

        });
        return textField;
    }

    private JButton getSearchButton() {
        JButton searchButton = new JButton(Constants.BUTTON_SEARCH);
        searchButton.addActionListener(e -> {

        });
        return searchButton;
    }

    private JButton getHistoryButton() {
        JButton historyButton = new JButton(Constants.BUTTON_HISTORY);
        historyButton.addActionListener(e -> {

        });
        return historyButton;
    }

}
