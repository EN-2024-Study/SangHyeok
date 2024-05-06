import utility.Constants;
import view.smallNumberPanel;
import view.KeypadPanel;
import view.BigNumberPanel;
import view.TopPanel;

import javax.swing.*;
import java.awt.*;

public class Main extends JFrame {

    public Main() {
        initFrame();
        setFrameByLayout();
        setVisible(true);
    }

    private void initFrame() {
        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new GridBagLayout());
    }

    private void setFrameByLayout() {
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.BOTH;
        c.gridx = 0;
        c.weightx = 1;

        c.gridy = 0;
        c.weighty = 0.2;
        add(new TopPanel(), c);

        c.gridy = 1;
        c.weighty = 0.3;
        add(new smallNumberPanel(), c);

        c.gridy = 2;
        c.weighty = 0.4;
        add(new BigNumberPanel(), c);

        c.gridy = 3;
        c.weighty = 0.7;
        add(new KeypadPanel(), c);

        setSize(450, 600);
    }

    public static void main(String[] args) {
        new Main();
    }
}
