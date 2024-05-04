import Dao.ImageDao;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class SearchedActionListener {

    private JFrame frame;
    private Components components;

    public SearchedActionListener(JFrame frame, Components component) {
        this.frame = frame;
        this.components = component;
    }

    public void actionListenerForSearchButton() throws IOException, ParseException {
        ImageDao imageDao = new ImageDao(components.getTextField().getText());
        components.setImageLabels(imageDao.getImageLabels());
        setSearchedPanel();
    }

    public void actionListenerForGoBackButton() {
        frame.getContentPane().removeAll();
        frame.add(components.getSearchPanel());
        restartFrame();
    }

    public void actionListenerForComboBox() throws IOException, ParseException {
        setSearchedPanel();
    }

    public void actionListenerForHistoryButton() {
        frame.getContentPane().removeAll();
        frame.add(components.getSearchPanel(), BorderLayout.NORTH);
        restartFrame();
    }

    private void setSearchedPanel() throws IOException, ParseException {
        frame.getContentPane().removeAll();
        frame.add(components.getSearchedPanel(), BorderLayout.NORTH);
        frame.add(components.getImagePanel(), BorderLayout.CENTER);
        restartFrame();
    }

    private void restartFrame() {
        frame.revalidate();
        frame.repaint();
    }
}