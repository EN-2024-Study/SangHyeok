import org.json.simple.parser.ParseException;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;

public class MainFrame extends JFrame {

    private Components components;

    public MainFrame() {
        this.components = new Components(this);

        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        setLayout(new BorderLayout());
        add(components.getSearchPanel());

        setSize(600, 600);
        setVisible(true);
    }

    public static void main(String[] args) throws IOException, ParseException {
        new MainFrame();
    }
}