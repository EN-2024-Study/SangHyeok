package view;

import constant.Enums;

import java.util.HashMap;

public interface IView {
    void showScreen(Enums.ScreenType screenType);
    void showDialog(boolean isComplete, String text);
    HashMap<Enums.TextType, String> getText(Enums.ScreenType screenType);
    void setTextField(Enums.ScreenType screenType, HashMap<Enums.TextType, String> valueMap);
}
