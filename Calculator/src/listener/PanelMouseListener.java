package listener;

import controller.PanelManager;
import utility.Constants;

import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class PanelMouseListener extends MouseAdapter {

    private PanelManager panelManager;

    public PanelMouseListener(PanelManager panelManager) {
        this.panelManager = panelManager;
    }

    @Override
    public void mousePressed(MouseEvent e) {
        if (e.getSource().getClass().toString().contains(Constants.HISTORY_BUTTON_PANEL) ||
                e.getSource().getClass().toString().contains(Constants.SMALL_NUMBER_PANEL) ||
                e.getSource().getClass().toString().contains(Constants.BIG_NUMBER_PANEL)) {
            panelManager.hideHistoryPanel();
            panelManager.processTopPanelMouseListener(false);
            panelManager.processKeypadActionPaint(Constants.EQUAL_STRING);
        }
    }
}
