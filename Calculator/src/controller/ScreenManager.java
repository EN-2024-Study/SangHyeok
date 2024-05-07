package controller;

import model.ListenerVo;
import model.PanelVo;
import observer.ButtonActionListener;
import observer.FrameComponentListener;
import utility.Constants;
import view.historyPanel.DownHistoryPanel;
import view.historyPanel.RightHistoryPanel;
import view.mainPanel.*;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentEvent;

public class ScreenManager {

    private Main frame;
    private PanelVo panelVo;
    private ListenerVo listenerVo;

    public ScreenManager(Main frame) {
        this.frame = frame;
        this.listenerVo = new ListenerVo(new FrameComponentListener(this), new ButtonActionListener(this));
        this.panelVo = new PanelVo(new HistoryButtonPanel(listenerVo.getButtonActionListener()), new SmallNumberPanel(), new BigNumberPanel(),
                new KeypadPanel(listenerVo.getButtonActionListener()), new RightHistoryPanel(listenerVo.getButtonActionListener()), new DownHistoryPanel(listenerVo.getButtonActionListener()));
    }

    public void initFrame() {
        frame.setTitle(Constants.TITLE);
        frame.setLayout(new GridLayout(1, 1));
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.addComponentListener(listenerVo.getFrameComponentListener());
        frame.add(getMainPanel(panelVo));
    }

    private JPanel getMainPanel(PanelVo panelVo) {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();

        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.3;
        mainPanel.add(getTopPanel(panelVo), c);

        c.gridy = 2;
        c.weighty = 0.7;
        mainPanel.add(panelVo.getKeypadPanel(), c);
        return mainPanel;
    }

    private JPanel getTopPanel(PanelVo panelVo) {
        JPanel topPanel = new JPanel();
        topPanel.setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.2;
        topPanel.add(panelVo.getHistoryButtonPanel(), c);

        c.gridy = 1;
        c.weighty = 0.3;
        topPanel.add(panelVo.getSmallNumberPanel(), c);

        c.gridy = 2;
        c.weighty = 0.4;
        topPanel.add(panelVo.getBigNumberPanel(), c);
        return topPanel;
    }

    public void deleteHistory() {

    }

    public void showDonwHistoryPanel() {
        System.out.println("showDonwHistoryPanel");
        frame.setLayout(new GridLayout(2, 1));
        frame.add(panelVo.getDownHistoryPanel());

        frame.revalidate();
        frame.repaint();
    }

    public void showRightHistoryPanel() {
        panelVo.getHistoryButtonPanel().hideButton();

        frame.setLayout(new GridLayout(1, 2));
        frame.add(panelVo.getRightHistoryPanel());

        frame.revalidate();
        frame.repaint();
    }

    public void hideRightHistoryPanel() {
        panelVo.getHistoryButtonPanel().showButton();
        frame.remove(panelVo.getRightHistoryPanel());
    }

    public void preventFrameFromSize(ComponentEvent e) {
        frame.setSize(new Dimension(400, e.getComponent().getSize().height));
    }
}
