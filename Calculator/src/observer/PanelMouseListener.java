package observer;

import controller.ScreenManager;
import model.PanelVo;
import view.mainPanel.Main;

import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class PanelMouseListener extends MouseAdapter {

    private PanelVo panelVo;
    private ScreenManager screenManager;

    public PanelMouseListener(PanelVo panelVo, ScreenManager screenManager) {
        this.panelVo = panelVo;
        this.screenManager = screenManager;
    }

    @Override
    public void mouseClicked(MouseEvent e) {
        if (e.getComponent().equals(panelVo.getHistoryButtonPanel()) ||
                e.getComponent().equals(panelVo.getSmallNumberPanel()) ||
                e.getComponent().equals(panelVo.getBigNumberPanel())) {
            screenManager.hideHistoryPanel();
            panelVo.getHistoryButtonPanel().removeMouseListener(this);
            panelVo.getSmallNumberPanel().removeMouseListener(this);
            panelVo.getBigNumberPanel().removeMouseListener(this);
        }
    }
}
