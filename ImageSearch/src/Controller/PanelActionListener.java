package Controller;

import Model.ImageDao;
import Model.SearchedStringDao;
import View.Components;
import org.json.simple.parser.ParseException;

import java.util.ArrayList;
import java.util.List;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.sql.SQLException;

public class PanelActionListener {

    private JFrame frame;
    private JFrame pastFrame;
    private Components components;

    private SearchedStringDao searchedStringDao;

    public PanelActionListener(JFrame frame, Components component) throws SQLException {
        this.frame = frame;
        this.components = component;
        this.searchedStringDao = new SearchedStringDao();
    }

    public void actionForSearchButton() throws IOException, ParseException, SQLException {
        searchedStringDao.insert(components.getTextField().getText());

        ImageDao imageDao = new ImageDao(components.getTextField().getText());
        components.setImageLabels(imageDao.getImageLabels());

        pastFrame = frame;
        frame.getContentPane().removeAll();
        frame.add(components.getSearchedPanel(), BorderLayout.NORTH);
        frame.add(components.getImagePanel(), BorderLayout.CENTER);
        restartFrame();
    }

    public void actionForGoBackButton() {
//        frame.getContentPane().removeAll();
//        frame.setContentPane(pastFrame);
//        restartFrame();
    }

    public void actionForHistoryButton() throws SQLException {
        List<JLabel> historyLabels = new ArrayList<>();
        List<String> historys = searchedStringDao.selectAll();
        for(String item : historys)
            historyLabels.add(new JLabel(item));
        components.setHistoryLabels(historyLabels);

        pastFrame = frame;
        frame.getContentPane().removeAll();
        frame.add(components.getHistoryPanel());
        restartFrame();
    }

    public void actionForDeleteButton() throws SQLException {
        List<String> searchedStrings = searchedStringDao.selectAll();

        for(String item : searchedStrings) {
            searchedStringDao.delete(item);
        }

        components.setHistoryLabels(new ArrayList<>());
        frame.getContentPane().removeAll();
        frame.add(components.getHistoryPanel());
        restartFrame();
    }

    public void actionListenerForComboBox() throws IOException, ParseException {
        frame.getContentPane().remove(1);
        frame.add(components.getImagePanel(), BorderLayout.CENTER);
        restartFrame();
    }

    private void restartFrame() {
        frame.revalidate();
        frame.repaint();
    }
}