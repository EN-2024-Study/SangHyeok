package observer;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class ButtonMouserListener extends MouseAdapter {

    @Override
    public void mousePressed(MouseEvent e) {
        JButton button = (JButton) e.getComponent();
        button.setBorder(BorderFactory.createLineBorder(new Color(130, 146, 164)));
    }

    @Override
    public void mouseReleased(MouseEvent e) {
        JButton button = (JButton) e.getComponent();
        button.setBorder(BorderFactory.createLineBorder(new Color(255, 255, 255)));
    }
}
