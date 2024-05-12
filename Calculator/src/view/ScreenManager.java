package view;

import listener.repository.ListenerRepository;
import controller.CalculationManager;
import utility.Constants;
import view.repository.PanelRepository;
import view.mainPanel.*;

import javax.swing.*;
import java.awt.*;

public class ScreenManager {

    private ListenerRepository listenerRepository;
    private PanelRepository panelRepository;
    private MainFrame frame;

    public ScreenManager() {
        CalculationManager calculationManager = new CalculationManager();

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
        mainPanel.add(this.panelRepository.getKeypadPanel(), c);
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
        topPanel.add(this.panelRepository.getHistoryButtonPanel(), c);

        c.gridy = 1;
        c.weighty = 0.3;
        topPanel.add(this.panelRepository.getSmallNumberPanel(), c);

        c.gridy = 2;
        c.weighty = 0.4;
        topPanel.add(this.panelRepository.getBigNumberPanel(), c);
        return topPanel;
    }

    public void showDownHistoryPanel() {
        this.panelRepository.getKeypadPanel().setVisible(false);
        this.frame.setLayout(new GridLayout(2, 1));
        this.frame.add(this.panelRepository.getDownHistoryPanel());

        setTopPanelBackground(new Color(171, 171, 171));
        restartFrame();
    }

    public void showRightHistoryPanel() {
        this.panelRepository.getHistoryButtonPanel().hideButton();

        this.frame.setLayout(new GridLayout(1, 2));
        this.frame.add(this.panelRepository.getRightHistoryPanel());
        restartFrame();
    }

    public void hideHistoryPanel() {
        this.panelRepository.getHistoryButtonPanel().showButton();

        this.frame.remove(this.panelRepository.getRightHistoryPanel());
        this.frame.remove(this.panelRepository.getDownHistoryPanel());

        this.frame.setLayout(new GridLayout(1, 1));
        this.panelRepository.getKeypadPanel().setVisible(true);

        setTopPanelBackground(Color.WHITE);
        restartFrame();
    }

    private void setTopPanelBackground(Color color) {
        this.panelRepository.getHistoryButtonPanel().setBackground(color);
        this.panelRepository.getSmallNumberPanel().setBackground(color);
        this.panelRepository.getBigNumberPanel().setBackground(color);
    }

    public void setBigNumber(String number) {
        this.panelRepository.getBigNumberPanel().setNumber(number);
        setBigNumberFont();
    }

    public void setSmallNumber(String state) {
        this.panelRepository.getSmallNumberPanel().setNumber(state);
    }

    public void setBigNumberFont() {
        this.panelRepository.getBigNumberPanel().setFont(this.frame.getWidth());
    }

    public void processTopPanelMouseListener(boolean isAdd) {
        if (isAdd) {
            this.panelRepository.getHistoryButtonPanel().addMouseListener(this.listenerRepository.getPanelMouseListener());
            this.panelRepository.getSmallNumberPanel().addMouseListener(this.listenerRepository.getPanelMouseListener());
            this.panelRepository.getBigNumberPanel().addMouseListener(this.listenerRepository.getPanelMouseListener());
            return;
        }

        this.panelRepository.getHistoryButtonPanel().removeMouseListener(this.listenerRepository.getPanelMouseListener());
        this.panelRepository.getSmallNumberPanel().removeMouseListener(this.listenerRepository.getPanelMouseListener());
        this.panelRepository.getBigNumberPanel().removeMouseListener(this.listenerRepository.getPanelMouseListener());
    }

    public void processKeypadActionPaint(String buttonPressed) {
        JButton[] buttons = this.panelRepository.getKeypadPanel().getButtons();
        for (JButton button : buttons) {
            if (button.getText().equals(buttonPressed)) {
                button.setFocusable(true);
                button.setFocusPainted(true);
                button.requestFocus();
                break;
            }
        }
    }

    public void processKeypadActionListener(boolean isEnabled) {
        JButton[] buttons = this.panelRepository.getKeypadPanel().getButtons();
        String[] noActionButtons = new String[]{Constants.DIVIDE_STRING, Constants.MULTIPLY_STRING, Constants.SUBTRACT_STRING, Constants.ADD_STRING, Constants.POINT_STRING, Constants.SIGN_STRING};

        for (JButton button : buttons) {
            for (String noActionButton : noActionButtons) {
                if (button.getText().equals(noActionButton)) {
                    button.setEnabled(isEnabled);
                    break;
                }
            }
        }
    }

    private void restartFrame() {
        this.frame.revalidate();
        this.frame.repaint();
    }
}