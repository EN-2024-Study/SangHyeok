package listener;

import controller.PanelManager;

import java.awt.event.*;

public class ComponentListener extends ComponentAdapter {

    private PanelManager panelManager;

    public ComponentListener(PanelManager panelManager) {
        this.panelManager = panelManager;
    }

    @Override
    public void componentResized(ComponentEvent e) {
        this.panelManager.setBigNumberFont();

        if (e.getComponent().getSize().width > 800) {
            this.panelManager.showRightHistoryPanel();
            this.panelManager.addRightHistoryPanelWidth();
        }
        if (e.getComponent().getSize().width < 700) {
            this.panelManager.hideHistoryPanel();
            this.panelManager.removeRightHistoryPanelWidth();
        }
    }
}
