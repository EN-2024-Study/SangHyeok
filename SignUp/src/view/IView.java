package view;

import constant.Enums;

import javax.swing.*;
import java.util.HashMap;

public interface IView {
    void showScreen(Enums.ScreenType screenType);
    HashMap<Enums.TextType, String> getText(Enums.ScreenType screenType);
}
