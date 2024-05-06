import utility.Constants;
import view.KeypadPanel;
import view.OutputPanel;

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
        c.gridx = 0;
        c.gridy = 0;
        c.weightx = 1;
        c.weighty = 0.4;
        c.fill = GridBagConstraints.BOTH;
        add(new OutputPanel(), c);

        c.gridy = 1;
        c.weighty = 0.4;
        add(new KeypadPanel(), c);

        setSize(450, 600);
    }

    public static void main(String[] args) {
        new Main();
    }
}
