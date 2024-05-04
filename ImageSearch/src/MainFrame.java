import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {

    private MainPanel mainPanel;

    public MainFrame() {
        this.mainPanel = new MainPanel(this);

        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        setLayout(new FlowLayout());
        add(mainPanel.getSearchPanel());
        setSize(600, 600);
        setVisible(true);
    }

    public static void main(String[] args) {
        new MainFrame();
    }
}