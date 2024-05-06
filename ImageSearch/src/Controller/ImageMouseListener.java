package Controller;

import View.Components;
import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.IOException;

public class ImageMouseListener extends MouseAdapter {

    private JFrame frame;
    private Components components;

    public ImageMouseListener(JFrame frame, Components components) {
        this.frame = frame;
        this.components = components;
    }

    @Override
    public void mouseClicked(MouseEvent e) {
        if (e.getButton() == MouseEvent.BUTTON1) {
            if (e.getClickCount() == 2) {
                try {
                    setLabelSize(e);
                } catch (IOException | ParseException ex) { // 좀 더 상세하게 예외처리하기
                    throw new RuntimeException(ex);
                }
            }
        }
    }

    private void setLabelSize(MouseEvent e) throws IOException, ParseException {
        JLabel label = (JLabel) e.getSource();
        ImageIcon image = (ImageIcon)label.getIcon();
        JDialog imageDialog = components.getBigImagePanel(image);

        imageDialog.setSize(new Dimension(frame.getWidth() - 100, frame.getHeight() - 100));
        imageDialog.revalidate();
        imageDialog.repaint();
        imageDialog.setVisible(true);
    }

}
