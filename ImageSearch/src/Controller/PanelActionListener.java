package Controller;

import Model.ImageDao;
import Model.SearchedStringDao;
import Utility.Constants;
import View.Components;
import org.json.simple.parser.ParseException;

import java.util.ArrayList;
import java.util.List;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.sql.SQLException;
import java.util.regex.Pattern;

public class PanelActionListener {

    private JFrame frame;
    private Components components;

    private SearchedStringDao searchedStringDao;

    public PanelActionListener(JFrame frame, Components component) throws SQLException {
        this.frame = frame;
        this.components = component;
        this.searchedStringDao = new SearchedStringDao();
    }

    public void actionForSearchButton() throws SQLException, IOException, ParseException {
        String insertQyery = components.getTextField().getText();
        if (!isInputStringValid(insertQyery)) {
            setOptionPane();
            frame.getContentPane().removeAll();
            frame.add(components.getSearchPanel());
            reStartFrame();
            return;
        }

        setSearchedPanel(insertQyery);
    }

    public void actionForHistoryButton() throws SQLException {
        List<JLabel> historyLabels = new ArrayList<>();
        List<String> historyStrings = searchedStringDao.selectAll();
        for (String item : historyStrings)
            historyLabels.add(new JLabel(item));
        components.setHistoryLabels(historyLabels);

        JPanel panel = components.getHistoryPanel();
//        panel.add(components.getGoSearchPanelButton());

        frame.getContentPane().removeAll();
        frame.add(panel);
        reStartFrame();
    }

    public void actionForDeleteButton() throws SQLException {
        List<String> searchedStrings = searchedStringDao.selectAll();

        for (String item : searchedStrings) {
            searchedStringDao.delete(item);
        }

        components.setHistoryLabels(new ArrayList<>());
        frame.getContentPane().removeAll();
        frame.add(components.getHistoryPanel());
        reStartFrame();
    }

    public void actionGoSearchPanel() {
        frame.getContentPane().removeAll();
        frame.add(components.getSearchPanel());
        reStartFrame();
    }

    public void actionListenerForComboBox() throws IOException, ParseException {
        frame.getContentPane().remove(1);
        frame.add(components.getImagePanel(), BorderLayout.CENTER);
        reStartFrame();
    }

    private void setSearchedPanel(String str) throws SQLException, IOException, ParseException {
        searchedStringDao.insert(str);

        ImageDao imageDao = new ImageDao(components.getTextField().getText());
        components.setImageLabels(imageDao.getImageLabels());

        JPanel panel = components.getSearchedPanel();
        panel.add(components.getGoSearchPanelButton());

        frame.getContentPane().removeAll();
        frame.add(panel, BorderLayout.NORTH);
        frame.add(components.getImagePanel(), BorderLayout.CENTER);
        reStartFrame();
    }

    private void setOptionPane() {
        JOptionPane.showMessageDialog(null, Constants.ERROR_MESSAGE, "Error", JOptionPane.ERROR_MESSAGE);
    }

    private void reStartFrame() {
        frame.revalidate();
        frame.repaint();
    }

    private boolean isInputStringValid(String inputString) {
        Pattern pattern = Pattern.compile("[ !@#$%^&*(),.?\":{}|<>]");
        if (inputString.equals("") || pattern.matcher(inputString).matches())
            return false;
        return true;
    }
}