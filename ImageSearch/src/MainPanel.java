import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.List;

public class MainPanel extends JPanel {

    private JFrame frame;
    private ImageDao imageDao;
    private JTextField textField;

    public MainPanel(JFrame frame) {
        this.frame = frame;
        this.textField = new JTextField(15);
    }

    public JPanel getSearchPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());

        panel.add(textField);
        panel.add(getSearchButton());
        panel.add(getHistoryButton());
        return panel;
    }

    private JPanel getSearchedPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());
        panel.add(textField);
        panel.add(getSearchButton());
        panel.add(getGoBackButton());
        return panel;
    }

    private JButton getSearchButton() {
        JButton searchButton = new JButton(Constants.BUTTON_SEARCH);
        searchButton.addActionListener(e -> {
            try {
                actionListenerForSearchButton();
            } catch (IOException | ParseException ex) {
                throw new RuntimeException(ex);
            }
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

    private void actionListenerForSearchButton() throws IOException, ParseException {
        imageDao = new ImageDao(textField.getText());
        List<JLabel> labels = imageDao.getImageLabels();
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout(FlowLayout.CENTER, 10, 10));
        for(JLabel label : labels)
            panel.add(label);

        frame.getContentPane().removeAll();
        frame.add(getSearchedPanel(), BorderLayout.NORTH);
        frame.add(panel, BorderLayout.CENTER);
        frame.revalidate();
        frame.repaint();

    }
}
