package view.screen;

import constant.Enums;
import view.screen.panel.TextFieldPanel;

import java.util.HashMap;

public interface IScreen {
    HashMap<Enums.TextType, String> getText();
    void resetTextField();
}
