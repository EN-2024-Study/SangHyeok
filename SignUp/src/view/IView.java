package view;

import constant.Enums;

import javax.swing.*;
import java.util.HashMap;

public interface IView {
    void showScreen(JPanel panel);
    HashMap<Enums.TextType, String> getText(Enums.ScreenType screenType);
}
