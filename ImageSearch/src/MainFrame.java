import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {

    private SearchPanel searchPanel;
    private SearchedPanel searchedPanel;

    public MainFrame() {
        this.searchPanel = new SearchPanel();
        this.searchedPanel = new SearchedPanel();

        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        setLayout(new FlowLayout());
        add(searchPanel);
        setSize(600, 600);
        setVisible(true);
    }

    private class SearchPanel extends JPanel {

        private SearchPanel() {
            setLayout(new FlowLayout());
            add(getTextField());
            add(getSearchButton());
            add(getHistoryButton());
        }
    }

    private class SearchedPanel extends JPanel {

        private SearchedPanel() {
            setLayout(new FlowLayout());
            add(getTextField());
            add(getSearchButton());
            add(getGoBackButton());
        }
    }


    private JTextField getTextField() {
        JTextField textField = new JTextField(15);
//        textField.addActionListener(e -> {
//        });
        return textField;
    }

    private JButton getSearchButton() {
        JButton searchButton = new JButton(Constants.BUTTON_SEARCH);
        searchButton.addActionListener(e -> {
            remove(searchPanel);
            add(searchedPanel);
            revalidate();
            repaint();
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
            remove(searchedPanel);
            add(searchPanel);
            revalidate();
            repaint();
        });
        return goBackButton;
    }

    public static void main(String[] args) {
        new MainFrame();
    }
}