import Model.PanelVo;
import observer.FrameComponentListener;
import utility.Constants;
import view.LogPanel.HistoryPanel;
import view.LogPanel.ResultScrollPane;
import view.MainPanel.SmallNumberPanel;
import view.MainPanel.KeypadPanel;
import view.MainPanel.BigNumberPanel;
import view.MainPanel.TopPanel;

import javax.swing.*;
import java.awt.*;

public class Main extends JFrame {

    private PanelVo panelVo;

    public Main() {
        init();
        setFrameByLayout();
        setVisible(true);
    }

    private void init() {
        panelVo = new PanelVo(new TopPanel(), new SmallNumberPanel(), new BigNumberPanel(), new KeypadPanel(), new HistoryPanel());
        initFrame();
    }

    private void initFrame() {
        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        addComponentListener(new FrameComponentListener(this, panelVo));
    }

    private void setFrameByLayout() {
        setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.2;
        add(panelVo.getTopPanel(), c);

        c.gridy = 1;
        c.weighty = 0.3;
        add(panelVo.getSmallNumberPanel(), c);

        c.gridy = 2;
        c.weighty = 0.4;
        add(panelVo.getBigNumberPanel(), c);

        c.gridy = 3;
        c.weighty = 0.7;
        add(panelVo.getKeypadPanel(), c);

        setSize(450, 600);
    }

    public static void main(String[] args) {
        new Main();
    }
}
