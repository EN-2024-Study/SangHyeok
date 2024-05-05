package Controller;

import Model.ImageDao;
import Model.SearchedStringDao;
import View.Components;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;

public class HistoryMouseListener extends MouseAdapter {

    private JFrame frame;
    private Components components;

    public HistoryMouseListener(JFrame frame, Components components) throws SQLException {
        this.frame = frame;
        this.components = components;
    }

    @Override
    public void mouseClicked(MouseEvent e) {
        if (e.getButton() == MouseEvent.BUTTON1) {
            if (e.getClickCount() == 2) {
                try {
                    setImageLabels(e);
                    setSearchedPanel(e);
                } catch (IOException | ParseException ex) {
                    throw new RuntimeException(ex);
                }
            }
        }
    }

    private void setImageLabels(MouseEvent e) throws IOException, ParseException {
        List<JLabel> historyLabels = components.getHistoryLabels();
        for (JLabel label : historyLabels) {
            if (e.getSource() == label) {
                ImageDao imageDao = new ImageDao(label.getText());
                components.setImageLabels(imageDao.getImageLabels());
                break;
            }
        }
    }

    private void setSearchedPanel(MouseEvent e) throws IOException, ParseException {
        JPanel panel = components.getSearchedPanel();
        panel.add(components.getGoSearchPanelButton());

        frame.getContentPane().removeAll();
        frame.add(panel, BorderLayout.NORTH);
        frame.add(components.getImagePanel(), BorderLayout.CENTER);
        frame.revalidate();
        frame.repaint();
    }
}
