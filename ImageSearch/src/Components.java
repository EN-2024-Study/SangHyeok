import Dao.ImageDao;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.List;

public class Components {

    private JFrame frame;
    private MainPanel mainPanel;

    public Components(JFrame frame, MainPanel mainPanel) {
        this.frame = frame;
        this.mainPanel = mainPanel;
    }

    public JButton getSearchButton() {
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

    public JButton getHistoryButton() {
        JButton historyButton = new JButton(Constants.BUTTON_HISTORY);
//        historyButton.addActionListener(e -> {
//        });
        return historyButton;
    }

    public JButton getGoBackButton() {
        JButton goBackButton = new JButton(Constants.BUTTTON_GOBACK);
        goBackButton.addActionListener(e -> {
            frame.getContentPane().removeAll();
            frame.add(mainPanel.getSearchPanel());
            frame.revalidate();
            frame.repaint();
        });
        return goBackButton;
    }

    public void actionListenerForSearchButton() throws IOException, ParseException {
        ImageDao imageDao = new ImageDao(mainPanel.getTextField().getText());
        List<JLabel> labels = imageDao.getImageLabels();
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout(FlowLayout.CENTER, 10, 10));
        for(JLabel label : labels)
            panel.add(label);

        frame.getContentPane().removeAll();
        frame.add(mainPanel.getSearchedPanel(), BorderLayout.NORTH);
        frame.add(panel, BorderLayout.CENTER);
        frame.revalidate();
        frame.repaint();
    }
}
