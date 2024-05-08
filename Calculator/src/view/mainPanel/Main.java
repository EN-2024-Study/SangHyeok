package view.mainPanel;

import controller.ScreenManager;
import model.ListenerVo;
import model.PanelVo;
import observer.FrameComponentListener;
import utility.Constants;

import javax.swing.*;
import java.awt.*;

public class Main extends JFrame {

    public Main() {
        new ScreenManager(this);
        setSize(450, 600);
        setVisible(true);
    }

    public void initFrame(PanelVo panelVo, ListenerVo listenerVo) {
        setTitle(Constants.TITLE);
        setLayout(new GridLayout(1, 1));
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        addKeyListener(listenerVo.getKeypadListener());
        addComponentListener(listenerVo.getFrameComponentListener());
        add(getMainPanel(panelVo));

        setFocusable(true);
        requestFocus();
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

    public static void main(String[] args) {
        new Main();
    }
}