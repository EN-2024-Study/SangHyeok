import Dao.ImageDao;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.List;

public class Components {

    private final JTextField textField;
    private final ButtonActionListener buttonActionListener;
    private Integer totalImageCount;

    public Components(JFrame frame) {
        this.buttonActionListener = new ButtonActionListener(frame, this);
        this.textField = new JTextField(15);
        this.totalImageCount = 10;
    }

    public JPanel getSearchPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());

        panel.add(textField);
        panel.add(getSearchButton());
        panel.add(getHistoryButton());
        return panel;
    }

    public JPanel getSearchedPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());

        panel.add(textField);
        panel.add(getSearchButton());
        panel.add(getComboBox());
        panel.add(getGoBackButton());
        return panel;
    }

    public JButton getSearchButton() {
        JButton searchButton = new JButton(Constants.BUTTON_SEARCH);
        searchButton.addActionListener(e -> {
            try {
                buttonActionListener.actionListenerForSearchButton();
            } catch (IOException | ParseException ex) {
                throw new RuntimeException(ex);
            }
        });
        return searchButton;
    }

    public JButton getHistoryButton() {
        JButton historyButton = new JButton(Constants.BUTTON_HISTORY);
//        historyButton.addActionListener(e -> {
//        });
        return historyButton;
    }

    public JButton getGoBackButton() {
        JButton goBackButton = new JButton(Constants.BUTTTON_GOBACK);
        goBackButton.addActionListener(e -> {
            buttonActionListener.actionListenerForGoBackButton();
        });
        return goBackButton;
    }

    public JComboBox getComboBox() {
        JComboBox searchComboBox = new JComboBox(Constants.COMBO_BOX);

        searchComboBox.addActionListener(e -> {
            try {
                buttonActionListener.actionListenerForComboBox(searchComboBox.getSelectedItem());
            } catch (IOException | ParseException ex) {
                throw new RuntimeException(ex);
            }
        });

        return searchComboBox;
    }

    public JTextField getTextField() {
        return textField;
    }

    public int getTotalImageCount() {
        return totalImageCount;
    }

    public void setTotalImageCount(int totalImageCount) {
        this.totalImageCount = totalImageCount;
    }
}
