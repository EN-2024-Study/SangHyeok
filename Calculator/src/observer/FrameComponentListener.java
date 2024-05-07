package observer;

import model.PanelVo;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class FrameComponentListener extends ComponentAdapter {

    private Frame frame;
    private PanelVo panelVo;

    public FrameComponentListener(Frame frame, PanelVo panelVo) {
        this.frame = frame;
        this.panelVo = panelVo;
    }

    @Override
    public void componentResized(ComponentEvent e) {
        if (e.getComponent().getSize().width > 900)
            setFrameByHistorypanel();

        if (e.getComponent().getSize().width < 700) {
            panelVo.getHistoryButtonPanel().showButton();
            frame.remove(panelVo.getRightHistoryPanel());
        }

        if (e.getComponent().getSize().width < 400)
            frame.setSize(new Dimension(400, e.getComponent().getSize().height));
    }

    private void setFrameByHistorypanel() {
        panelVo.getHistoryButtonPanel().hideButton();

        frame.add(panelVo.getRightHistoryPanel());
        frame.revalidate();
        frame.repaint();
    }
}
