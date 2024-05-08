package controller;

import model.*;
import observer.*;
import view.historyPanel.*;
import view.mainPanel.*;

import java.awt.*;

public class ScreenManager {

    private Main frame;
    private CalculationRepository calculationRepository;
    private CalculationManager calculationManager;
    private PanelVo panelVo;
    private ListenerVo listenerVo;

    public ScreenManager(Main frame) {
        this.frame = frame;
        this.calculationRepository = new CalculationRepository();
        this.calculationManager = new CalculationManager(this, calculationRepository);
        this.listenerVo = new ListenerVo(new ComponentListener(this), new ButtonListener(this, calculationManager),
                new KeypadListener(calculationManager), new PanelMouseListener(this));
        this.panelVo = new PanelVo(new HistoryButtonPanel(listenerVo.getButtonListener()), new SmallNumberPanel(), new BigNumberPanel(),
                new KeypadPanel(listenerVo.getKeypadListener()), new RightHistoryPanel(listenerVo.getButtonListener()), new DownHistoryPanel(listenerVo.getButtonListener()));

        frame.initFrame(panelVo, listenerVo);
    }

    public void showDownHistoryPanel() {
        panelVo.getKeypadPanel().setVisible(false);
        frame.setLayout(new GridLayout(2, 1));
        frame.add(panelVo.getDownHistoryPanel());
        setTopPanelBackground(new Color(171, 171, 171));

        restartFrame();
    }

    public void showRightHistoryPanel() {
        panelVo.getHistoryButtonPanel().hideButton();

        frame.setLayout(new GridLayout(1, 2));
        frame.add(panelVo.getRightHistoryPanel());
        restartFrame();
    }

    private void setTopPanelBackground(Color color) {
        panelVo.getHistoryButtonPanel().setBackground(color);
        panelVo.getSmallNumberPanel().setBackground(color);
        panelVo.getBigNumberPanel().setBackground(color);
    }

    public void addTopPanelMouseListener() {
        panelVo.getHistoryButtonPanel().addMouseListener(listenerVo.getPanelMouseListener());
        panelVo.getSmallNumberPanel().addMouseListener(listenerVo.getPanelMouseListener());
        panelVo.getBigNumberPanel().addMouseListener(listenerVo.getPanelMouseListener());
    }

    public void removeTopPanelMouseListener() {
        panelVo.getHistoryButtonPanel().removeMouseListener(listenerVo.getPanelMouseListener());
        panelVo.getSmallNumberPanel().removeMouseListener(listenerVo.getPanelMouseListener());
        panelVo.getBigNumberPanel().removeMouseListener(listenerVo.getPanelMouseListener());
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

    public void setBigNumber(boolean isFirst, String number) {
        panelVo.getBigNumberPanel().setNumber(isFirst, number);
    }

    private void restartFrame() {
        frame.revalidate();
        frame.repaint();
    }
}