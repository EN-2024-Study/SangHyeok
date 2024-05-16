package controller;

import form.MainFrame;
import listener.ButtonListener;
import listener.ComponentListener;
import listener.KeypadListener;
import listener.PanelMouseListener;
import utility.Constants;
import form.repository.PanelRepository;

import java.util.List;

import javax.swing.*;
import java.awt.*;

public class PanelManager {

    private PanelRepository panelRepository;
    private ButtonListener buttonListener;
    private ComponentListener componentListener;
    private KeypadListener keypadListener;
    private PanelMouseListener panelMouseListener;

    private JFrame frame;
    private StringTrimManager stringTrimManager;
    private int rightHistoryPanelWidth;

    public PanelManager() {
        initListener();

        this.panelRepository = new PanelRepository(buttonListener, keypadListener);
        this.frame = new MainFrame(getMainPanel(), componentListener, keypadListener);
        this.stringTrimManager = new StringTrimManager();
        this.rightHistoryPanelWidth = 0;
        setFrameFocus();
    }

    private void initListener() {
        CalculationManager calculationManager = new CalculationManager();
        this.buttonListener = new ButtonListener(this, calculationManager);
        this.componentListener = new ComponentListener(this);
        this.keypadListener = new KeypadListener(this, calculationManager);
        this.panelMouseListener = new PanelMouseListener(this);
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

    public void setFrameFocus() {
        this.frame.setFocusable(true);
        this.frame.requestFocus();
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

    public void setBigNumber(String number, boolean isInput) {
        String bigNumber = this.stringTrimManager.processComma(number);
        if (!isInput)
            bigNumber = this.stringTrimManager.processE(bigNumber);

        this.panelRepository.getBigNumberPanel().setNumber(bigNumber);
        setBigNumberFont();
    }

    public void setSmallNumber(String state) {
        String smallNumber = this.stringTrimManager.processE(state);
        this.panelRepository.getSmallNumberPanel().setNumber(smallNumber);
    }

    public void setBigNumberFont() {
        this.panelRepository.getBigNumberPanel().setFont(this.frame.getWidth() - this.rightHistoryPanelWidth);
    }

    public void addRightHistoryPanelWidth() {
        this.rightHistoryPanelWidth = this.panelRepository.getRightHistoryPanel().getWidth();
    }

    public void removeRightHistoryPanelWidth() {
        this.rightHistoryPanelWidth = 0;
    }

    public void processTopPanelMouseListener(boolean isAdd) {
        if (isAdd) {
            this.panelRepository.getHistoryButtonPanel().addMouseListener(panelMouseListener);
            this.panelRepository.getSmallNumberPanel().addMouseListener(panelMouseListener);
            this.panelRepository.getBigNumberPanel().addMouseListener(panelMouseListener);
            return;
        }

        this.panelRepository.getHistoryButtonPanel().removeMouseListener(panelMouseListener);
        this.panelRepository.getSmallNumberPanel().removeMouseListener(panelMouseListener);
        this.panelRepository.getBigNumberPanel().removeMouseListener(panelMouseListener);
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
        String[] noActionButtons = new String[]{Constants.EQUAL_STRING, Constants.DIVIDE_STRING, Constants.MULTIPLY_STRING, Constants.SUBTRACT_STRING, Constants.ADD_STRING, Constants.POINT_STRING, Constants.SIGN_STRING};

        for (JButton button : buttons) {
            for (String noActionButton : noActionButtons) {
                if (button.getText().equals(noActionButton)) {
                    button.setEnabled(isEnabled);
                    break;
                }
            }
        }
    }

    public void processHistoryScreen(List<String> historyStringList) {
        this.panelRepository.getDownHistoryPanel().setHistoryList(buttonListener, historyStringList);
        this.panelRepository.getDownHistoryPanel().setScrollPane();
        this.panelRepository.getDownHistoryPanel().setHistoryPanel();

        this.panelRepository.getRightHistoryPanel().setHistoryList(buttonListener, historyStringList);
        this.panelRepository.getRightHistoryPanel().setScrollPane();
        this.panelRepository.getRightHistoryPanel().setHistoryPanel();
        restartFrame();
    }

    private void restartFrame() {
        this.frame.revalidate();
        this.frame.repaint();
    }
}