package observer;

import controller.ScreenManager;
import model.PanelVo;
import view.mainPanel.Main;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class FrameComponentListener extends ComponentAdapter {

    private ScreenManager screenManager;

    public FrameComponentListener(ScreenManager screenManager) {
        this.screenManager = screenManager;
    }

    @Override
    public void componentResized(ComponentEvent e) {
        if (e.getComponent().getSize().width > 900)
            screenManager.showRightHistoryPanel();

        if (e.getComponent().getSize().width < 700)
            screenManager.hideRightHistoryPanel();

        if (e.getComponent().getSize().width < 400)
            screenManager.preventFrameFromSize(e);
    }
}
