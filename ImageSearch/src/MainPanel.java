import Dao.ImageDao;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.List;

public class MainPanel extends JPanel {

    private Components components;
    private JTextField textField;

    public MainPanel(JFrame frame) {
        components = new Components(frame, this);
        this.textField = new JTextField(15);
    }

    public JPanel getSearchPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());

        panel.add(textField);
        panel.add(components.getSearchButton());
        panel.add(components.getHistoryButton());
        return panel;
    }

    public JPanel getSearchedPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());
        panel.add(textField);
        panel.add(components.getSearchButton());
        panel.add(components.getGoBackButton());
        return panel;
    }

    public JTextField getTextField() {
        return textField;
    }
}
