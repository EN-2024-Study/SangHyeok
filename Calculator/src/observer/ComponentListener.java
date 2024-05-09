package observer;

import controller.ScreenManager;
import utility.Constants;

import javax.swing.*;
import java.awt.event.*;

public class ComponentListener extends ComponentAdapter {

    private ScreenManager screenManager;

    public ComponentListener(ScreenManager screenManager) {
        this.screenManager = screenManager;
    }

    @Override
    public void componentResized(ComponentEvent e) {
        screenManager.setBigNumberFont();

        if (e.getComponent().getSize().width > 800) {
            screenManager.showRightHistoryPanel();
        }
        if (e.getComponent().getSize().width < 700) {
            screenManager.hideHistoryPanel();
        }
    }
}
