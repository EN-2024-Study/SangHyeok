package controller;

import model.CalculationRepository;
import model.ListenerVo;
import model.PanelVo;
import observer.ButtonListener;
import observer.KeypadListener;
import observer.FrameComponentListener;
import observer.PanelMouseListener;
import view.historyPanel.DownHistoryPanel;
import view.historyPanel.RightHistoryPanel;
import view.mainPanel.*;

import java.awt.*;
import java.awt.event.ComponentEvent;
import java.awt.event.MouseAdapter;

public class ScreenManager {

    private Main frame;
    private CalculationRepository calculationRepository;
    private PanelVo panelVo;
    private ListenerVo listenerVo;

    public ScreenManager(Main frame) {
        this.frame = frame;
        this.calculationRepository = new CalculationRepository();
        this.listenerVo = new ListenerVo(new FrameComponentListener(this), new ButtonListener(this, calculationRepository), new KeypadListener(this, calculationRepository));
        this.panelVo = new PanelVo(new HistoryButtonPanel(listenerVo.getButtonListener()), new SmallNumberPanel(), new BigNumberPanel(),
                new KeypadPanel(listenerVo.getKeypadListener()), new RightHistoryPanel(listenerVo.getButtonListener()), new DownHistoryPanel(listenerVo.getButtonListener()));
        frame.initFrame(panelVo, listenerVo.getFrameComponentListener());
    }

    public void showDownHistoryPanel() {
        panelVo.getKeypadPanel().setVisible(false);
        frame.setLayout(new GridLayout(2, 1));
        frame.add(panelVo.getDownHistoryPanel());
        setTopPanelBackground(new Color(171, 171, 171));

        restartFrame();
    }

    private void setTopPanelBackground(Color color) {
        panelVo.getHistoryButtonPanel().setBackground(color);
        panelVo.getSmallNumberPanel().setBackground(color);
        panelVo.getBigNumberPanel().setBackground(color);
    }

    public void addTopPanelMouseListener() {
        MouseAdapter mouseAdapter = new PanelMouseListener(panelVo, this);

        panelVo.getHistoryButtonPanel().addMouseListener(mouseAdapter);
        panelVo.getSmallNumberPanel().addMouseListener(mouseAdapter);
        panelVo.getBigNumberPanel().addMouseListener(mouseAdapter);
    }

    public void showRightHistoryPanel() {
        panelVo.getHistoryButtonPanel().hideButton();

        frame.setLayout(new GridLayout(1, 2));
        frame.add(panelVo.getRightHistoryPanel());
        restartFrame();
    }

    public void hideHistoryPanel() {
        panelVo.getHistoryButtonPanel().showButton();
        frame.remove(panelVo.getRightHistoryPanel());
        frame.remove(panelVo.getDownHistoryPanel());

        frame.setLayout(new GridLayout(1, 1));
        panelVo.getKeypadPanel().setVisible(true);

        setTopPanelBackground(Color.WHITE);
        restartFrame();
    }

    public void preventFrameFromSize(ComponentEvent e) {
        frame.setSize(new Dimension(400, e.getComponent().getSize().height));
    }

    private void restartFrame() {
        frame.revalidate();
        frame.repaint();
    }
}