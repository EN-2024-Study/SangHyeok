package view;

import Listener.Repository.ListenerRepository;
import controller.CalculationManager;
import view.Repository.PanelRepository;
import view.mainPanel.*;

import javax.swing.*;
import java.awt.*;

public class ScreenManager {

    private ListenerRepository listenerRepository;
    private PanelRepository panelRepository;
    private MainFrame frame;

    public ScreenManager() {
        CalculationManager calculationManager = new CalculationManager(this);

        this.listenerRepository = new ListenerRepository(this, calculationManager);
        this.panelRepository = new PanelRepository(listenerRepository.getButtonListener(), listenerRepository.getKeypadListener());
        this.frame = new MainFrame(getMainPanel(), listenerRepository.getComponentListener(), listenerRepository.getKeypadListener());
    }

    private JPanel getMainPanel() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();

        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.3;
        mainPanel.add(getTopPanel(), c);

        c.gridy = 2;
        c.weighty = 0.7;
        mainPanel.add(panelRepository.getKeypadPanel(), c);
        return mainPanel;
    }

    private JPanel getTopPanel() {
        JPanel topPanel = new JPanel();
        topPanel.setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.2;
        topPanel.add(panelRepository.getHistoryButtonPanel(), c);

        c.gridy = 1;
        c.weighty = 0.3;
        topPanel.add(panelRepository.getSmallNumberPanel(), c);

        c.gridy = 2;
        c.weighty = 0.4;
        topPanel.add(panelRepository.getBigNumberPanel(), c);
        return topPanel;
    }

    public void showDownHistoryPanel() {
        panelRepository.getKeypadPanel().setVisible(false);
        frame.setLayout(new GridLayout(2, 1));
        frame.add(panelRepository.getDownHistoryPanel());

        setTopPanelBackground(new Color(171, 171, 171));
        restartFrame();
    }

    public void showRightHistoryPanel() {
        panelRepository.getHistoryButtonPanel().hideButton();

        frame.setLayout(new GridLayout(1, 2));
        frame.add(panelRepository.getRightHistoryPanel());
        restartFrame();
    }

    private void setTopPanelBackground(Color color) {
        panelRepository.getHistoryButtonPanel().setBackground(color);
        panelRepository.getSmallNumberPanel().setBackground(color);
        panelRepository.getBigNumberPanel().setBackground(color);
    }

    public void processTopPanelMouseListener(boolean isAdd) {
        if (isAdd) {
            panelRepository.getHistoryButtonPanel().addMouseListener(listenerRepository.getPanelMouseListener());
            panelRepository.getSmallNumberPanel().addMouseListener(listenerRepository.getPanelMouseListener());
            panelRepository.getBigNumberPanel().addMouseListener(listenerRepository.getPanelMouseListener());
            return;
        }

        panelRepository.getHistoryButtonPanel().removeMouseListener(listenerRepository.getPanelMouseListener());
        panelRepository.getSmallNumberPanel().removeMouseListener(listenerRepository.getPanelMouseListener());
        panelRepository.getBigNumberPanel().removeMouseListener(listenerRepository.getPanelMouseListener());
    }

    public void hideHistoryPanel() {
        panelRepository.getHistoryButtonPanel().showButton();

        frame.remove(panelRepository.getRightHistoryPanel());
        frame.remove(panelRepository.getDownHistoryPanel());

        frame.setLayout(new GridLayout(1, 1));
        panelRepository.getKeypadPanel().setVisible(true);

        setTopPanelBackground(Color.WHITE);
        restartFrame();
    }

    public void processKeypadAction(String buttonPressed) {
        JButton[] buttons = panelRepository.getKeypadPanel().getButtons();
        for (JButton button : buttons) {
            if (button.getText().equals(buttonPressed)) {
                button.setFocusable(true);
                button.setFocusPainted(true);
                button.requestFocus();
                break;
            }
        }
    }

    public void setBigNumber(String number) {
        panelRepository.getBigNumberPanel().setNumber(number);
        setBigNumberFont();
    }

    public void resetBigNumber() {
        panelRepository.getBigNumberPanel().resetNumber();
        setBigNumberFont();
    }

    public void deleteBigNumber() {
        panelRepository.getBigNumberPanel().deleteNumber();
        setBigNumberFont();
    }

    public void setBigNumberFont() {
        panelRepository.getBigNumberPanel().setFont(frame.getWidth());
    }

    private void restartFrame() {
        frame.revalidate();
        frame.repaint();
    }
}