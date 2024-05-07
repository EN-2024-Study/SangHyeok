package view.mainPanel;

import controller.ScreenManager;

import javax.swing.*;

public class Main extends JFrame {

    private ScreenManager screenManager;

    public Main() {
        this.screenManager = new ScreenManager(this);
        screenManager.initFrame();
        setSize(450, 600);
        setVisible(true);
    }

    public static void main(String[] args) {
        new Main();
    }
}