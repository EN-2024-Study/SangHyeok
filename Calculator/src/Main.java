import model.PanelVo;
import observer.FrameComponentListener;
import utility.Constants;
import view.historyPanel.RightHistoryPanel;
import view.mainPanel.SmallNumberPanel;
import view.mainPanel.KeypadPanel;
import view.mainPanel.BigNumberPanel;
import view.mainPanel.HistoryButtonPanel;

import javax.swing.*;
import java.awt.*;

public class Main extends JFrame {

    private PanelVo panelVo;
    private JPanel mainPanel;

    public Main() {
        init();
        setMainPanelByLayout();
        add(mainPanel);

        setSize(450, 600);
        setVisible(true);
    }

    private void init() {
        mainPanel = new JPanel();
        mainPanel.setLayout(new GridBagLayout());
        panelVo = new PanelVo(new HistoryButtonPanel(), new SmallNumberPanel(), new BigNumberPanel(), new KeypadPanel(), new RightHistoryPanel());
        setTitle(Constants.TITLE);
        setLayout(new GridLayout(1, 2));
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        addComponentListener(new FrameComponentListener(this, panelVo));
    }

    private void setMainPanelByLayout() {
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.2;
        mainPanel.add(panelVo.getHistoryButtonPanel(), c);

        c.gridy = 1;
        c.weighty = 0.3;
        mainPanel.add(panelVo.getSmallNumberPanel(), c);

        c.gridy = 2;
        c.weighty = 0.4;
        mainPanel.add(panelVo.getBigNumberPanel(), c);

        c.gridy = 3;
        c.weighty = 0.7;
        mainPanel.add(panelVo.getKeypadPanel(), c);
    }

    public static void main(String[] args) {
        new Main();
    }
}
