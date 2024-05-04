import Dao.ImageDao;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class ButtonActionListener {

    private JFrame frame;
    private Components components;
    private List<JLabel> imageLabels;

    public ButtonActionListener(JFrame frame, Components component) {
        this.frame = frame;
        this.components = component;
        this.imageLabels = new ArrayList<>();
    }

    public void actionListenerForSearchButton() throws IOException, ParseException {
        ImageDao imageDao = new ImageDao(components.getTextField().getText());
        imageLabels = imageDao.getImageLabels();
        setImagePanel();
    }

    public void actionListenerForGoBackButton() {
        frame.getContentPane().removeAll();
        frame.add(components.getSearchPanel());
        resetFrame();
    }

    public void actionListenerForComboBox(Object item) throws IOException, ParseException {
        components.setTotalImageCount((Integer)item);
        setImagePanel();
    }

    public void actionListenerForHistoryButton() {
        frame.getContentPane().removeAll();

    }

    private void setImagePanel() {
        JPanel panel = new JPanel();
        panel.setLayout(new FlowLayout(FlowLayout.CENTER, 10, 10));

        for(int i = 0; i < components.getTotalImageCount(); i++)
            panel.add(imageLabels.get(i));

        frame.getContentPane().removeAll();
        frame.add(components.getSearchedPanel(), BorderLayout.NORTH);
        frame.add(panel, BorderLayout.CENTER);
        resetFrame();
    }

    private void resetFrame() {
        frame.revalidate();
        frame.repaint();
    }
}
