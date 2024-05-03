import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {
    public MainFrame() {
        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        MainPanel mainPanel = new MainPanel();
        Container pane = getContentPane();
        pane.setLayout(new FlowLayout());
        pane.add(mainPanel.getSearchPanel());

        setSize(600, 600);
        setVisible(true);
    }


    public static void main(String[] args) {
        MainFrame mainFrame = new MainFrame();

    }
}
