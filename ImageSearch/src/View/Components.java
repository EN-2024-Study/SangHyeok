package View;

import Controller.*;
import Utility.*;
import org.json.simple.parser.ParseException;
import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.net.MalformedURLException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class Components {

    private final JTextField textField;
    private final PanelActionListener panelActionListener;
    private final ImageMouseListener imageMouseListener;
    private final HistoryMouseListener historyMouseListener;
    private Integer totalImageCount;
    private List<JLabel> imageLabels;
    private List<JLabel> historyLabels;

    public Components(JFrame frame) throws SQLException {
        this.panelActionListener = new PanelActionListener(frame, this);
        this.imageMouseListener = new ImageMouseListener(frame, this);
        this.historyMouseListener = new HistoryMouseListener(frame, this);
        this.textField = new JTextField(15);
        this.totalImageCount = 10;
        this.imageLabels = new ArrayList<>();
        this.historyLabels = new ArrayList<>();
    }

    public JPanel getSearchPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());
        panel.add(textField);
        panel.add(getSearchButton());
        panel.add(getHistoryButton());

        JPanel mainPanel = new JPanel() {
            ImageIcon imageIcon = new ImageIcon("src/Model/ImageRepository/Naver_Logo.jpg");
            final Image image = imageIcon.getImage();
            @Override
            public void paintComponent(Graphics g) {
                super.paintComponent(g);
                g.drawImage(image, 0, 0, getWidth(), getHeight(), this);
            }
        };
        mainPanel.add(panel);

        return mainPanel;
    }

    public JPanel getSearchedPanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout());

        panel.add(textField);
        panel.add(getSearchButton());
        panel.add(getComboBox());
        return panel;
    }

    public JPanel getHistoryPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BorderLayout());
        JPanel historyPanel = new JPanel();
        historyPanel.setLayout(new GridLayout(10, 1));

        mainPanel.add(getGoSearchPanelButton(), BorderLayout.EAST);
        mainPanel.add(getDeleteButton(), BorderLayout.WEST);
        for(JLabel label : historyLabels) {
            historyPanel.add(label);
        }
        mainPanel.add(historyPanel, BorderLayout.CENTER);
        return mainPanel;
    }

    public JButton getGoSearchPanelButton() {
        JButton button = new JButton(Constants.BUTTTON_GOBACK);
        button.addActionListener(e -> {
            try {
                panelActionListener.actionGoSearchPanel();
            } catch (MalformedURLException ex) {
                throw new RuntimeException(ex);
            }
        });
        return button;
    }

    public JButton getSearchButton() {
        JButton searchButton = new JButton(Constants.BUTTON_SEARCH);
        searchButton.addActionListener(e -> {
            try {
                panelActionListener.actionForSearchButton();
            } catch (IOException | ParseException | SQLException ex) {
                throw new RuntimeException(ex);
            }
        });
        return searchButton;
    }

    public JComboBox getComboBox() {
        JComboBox searchComboBox = new JComboBox(Constants.COMBO_BOX);

        searchComboBox.addActionListener(e -> {
            try {
                totalImageCount = (Integer) searchComboBox.getSelectedItem();
                panelActionListener.actionListenerForComboBox();
            } catch (IOException | ParseException ex) {
                throw new RuntimeException(ex);
            }
        });
        return searchComboBox;
    }

    public JPanel getImagePanel() throws IOException, ParseException {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout(FlowLayout.CENTER, 10, 10));

        for (int i = 0; i < getTotalImageCount(); i++)
            panel.add(imageLabels.get(i));

        return panel;
    }

    public JDialog getBigImagePanel(ImageIcon image) {
        return new JDialog() {
            @Override
            public void paint(Graphics g) {
                super.paint(g);
                g.drawImage(image.getImage(), 0, 0, getWidth(), getHeight(), null);
            }
        };
    }

    public JButton getHistoryButton() {
        JButton historyButton = new JButton(Constants.BUTTON_HISTORY);
        historyButton.addActionListener(e -> {
            try {
                panelActionListener.actionForHistoryButton();
            } catch (SQLException ex) {
                throw new RuntimeException(ex);
            }
        });
        return historyButton;
    }

    public JButton getDeleteButton() {
        JButton button = new JButton(Constants.BUTTTON_DELETE);
        button.addActionListener(e -> {
            try {
                panelActionListener.actionForDeleteButton();
            } catch (SQLException ex) {
                throw new RuntimeException(ex);
            }
        });
        return button;
    }

    public JTextField getTextField() {
        return textField;
    }

    public int getTotalImageCount() {
        return totalImageCount;
    }

    public List<JLabel> getHistoryLabels() {
        return historyLabels;
    }

    public void setImageLabels(List<JLabel> imageLabels) {
        this.imageLabels = imageLabels;
        for (JLabel label : imageLabels)
            label.addMouseListener(imageMouseListener);
    }

    public void setHistoryLabels(List<JLabel> historyLabel) {
        this.historyLabels = historyLabel;
        for(JLabel label : historyLabel)
            label.addMouseListener(historyMouseListener);
    }
}
