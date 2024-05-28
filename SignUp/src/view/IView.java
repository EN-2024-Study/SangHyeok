package view;

import constant.Enums;

import java.util.HashMap;

public interface IView {
    HashMap<Enums.TextType, String > getText(Enums.ScreenType screenType);
}
