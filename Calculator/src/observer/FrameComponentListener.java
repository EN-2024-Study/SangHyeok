package observer;

import Model.PanelVo;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class FrameComponentListener extends ComponentAdapter {

    private Frame frame;
    private PanelVo panelVo;
    private JPanel leftPanel;

    public FrameComponentListener(Frame frame, JPanel leftPanel, PanelVo panelVo) {
        this.frame = frame;
        this.panelVo = panelVo;
        this.leftPanel = leftPanel;
    }

    @Override
    public void componentResized(ComponentEvent e) {
        if (e.getComponent().getSize().width > 900)
            setFrame();

        if (e.getComponent().getSize().width < 700)
            frame.remove(panelVo.getHistoryPanel());

        if (e.getComponent().getSize().width < 400)
            frame.setSize(new Dimension(400, e.getComponent().getSize().height));
    }

    private void setFrame() {
        frame.add(leftPanel);
        frame.add(panelVo.getHistoryPanel());

        frame.revalidate();
        frame.repaint();
    }
}
