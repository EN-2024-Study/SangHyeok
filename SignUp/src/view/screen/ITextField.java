package view.screen;

import constant.Enums;

import java.util.HashMap;

public interface ITextField {
    HashMap<Enums.TextType, String> getText();
    void resetTextField();
}
