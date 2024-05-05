package View;

import Controller.*;
import Utility.*;
import javax.swing.*;
import java.awt.*;
import java.net.MalformedURLException;
import java.sql.SQLException;

public class MainFrame extends JFrame {

    private Components components;

    public MainFrame() throws SQLException, MalformedURLException {
        this.components = new Components(this);
        setTitle(Constants.TITLE);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());
        add(components.getSearchPanel());
        setSize(600, 600);
        setVisible(true);
    }

    public static void main(String[] args) throws SQLException, MalformedURLException {
        new MainFrame();
    }
}