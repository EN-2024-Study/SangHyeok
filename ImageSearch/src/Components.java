import Dao.ImageDao;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Components {

    private final JTextField textField;
    private final SearchedActionListener searchedActionListener;
    private Integer totalImageCount;
    private List<JLabel> imageLabels;

    public Components(JFrame frame) {
        this.searchedActionListener = new SearchedActionListener(frame, this);
        this.textField = new JTextField(15);
        this.totalImageCount = 10;
        this.imageLabels = new ArrayList<>();
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
                searchedActionListener.actionListenerForSearchButton();
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
            searchedActionListener.actionListenerForGoBackButton();
        });
        return goBackButton;
    }

    public JComboBox getComboBox() {
        JComboBox searchComboBox = new JComboBox(Constants.COMBO_BOX);

        searchComboBox.addActionListener(e -> {
            try {
                totalImageCount = (Integer)searchComboBox.getSelectedItem();
                searchedActionListener.actionListenerForComboBox();
            } catch (IOException | ParseException ex) {
                throw new RuntimeException(ex);
            }
        });
        return searchComboBox;
    }

    public JPanel getImagePanel() throws IOException, ParseException {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout(FlowLayout.CENTER, 10, 10));

        for(int i = 0; i < getTotalImageCount(); i++)
            panel.add(imageLabels.get(i));
        return panel;
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

    public void setImageLabels(List<JLabel> imageLabels) {
        this.imageLabels = imageLabels;
    }
}
