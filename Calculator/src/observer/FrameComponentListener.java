package observer;

import Model.PanelVo;
import view.LogPanel.HistoryPanel;

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
        if (e.getComponent().getSize().width > 1000)
            setFrameByLayout();
        if (e.getComponent().getSize().width < 644)
            frame.setSize(new Dimension(644, e.getComponent().getSize().height));
    }

    private void setFrameByLayout() {
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.BOTH;
        c.gridx = 10;
        c.gridy = 0;
        c.weightx = 1;
        c.weighty = 1;

        frame.add(panelVo.getHistoryPanel(), c);
        frame.pack();
        frame.revalidate();
        frame.repaint();
    }

}
