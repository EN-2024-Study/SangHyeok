package view.mainPanel;

import controller.ScreenManager;
import model.ListenerVo;
import model.PanelVo;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class Main extends JFrame {

    public Main() {
        new ScreenManager(this);
    }

    public void initFrame(PanelVo panelVo, ListenerVo listenerVo) {
        addKeyListener(listenerVo.getKeypadListener());
        addComponentListener(listenerVo.getComponentListener());
        setFocusable(true);
        requestFocus();

        setLayout(new GridLayout(1, 1));
        add(getMainPanel(panelVo));

        setTitle("계산기");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setMinimumSize(Constants.FRAME_MINI_SIZE);
        setSize(Constants.FRAME_MINI_SIZE);
        setVisible(true);
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

    public JPanel getTopPanel(PanelVo panelVo) {
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

    public static void main(String[] args) {
        new Main();
    }
}