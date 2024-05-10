package listener;

import view.ScreenManager;
import utility.Constants;

import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class PanelMouseListener extends MouseAdapter {

    private ScreenManager screenManager;

    public PanelMouseListener(ScreenManager screenManager) {
        this.screenManager = screenManager;
    }

    @Override
    public void mouseClicked(MouseEvent e) {
        if (e.getSource().getClass().toString().contains(Constants.HISTORY_BUTTON_PANEL) ||
                e.getSource().getClass().toString().contains(Constants.SMALL_NUMBER_PANEL) ||
                e.getSource().getClass().toString().contains(Constants.BIG_NUMBER_PANEL)) {
            screenManager.hideHistoryPanel();
            screenManager.processTopPanelMouseListener(false);
            screenManager.processKeypadAction(Constants.EQUAL_STRING);
        }
    }
}
