package model;

import observer.ButtonActionListener;
import observer.FrameComponentListener;
import observer.KeypadActionListener;

import java.awt.event.ActionListener;

public class ListenerVo {

    private ActionListener keypadActionListener, buttonActionListener;
    private FrameComponentListener frameComponentListener;

    public ListenerVo(FrameComponentListener frameComponentListener, ActionListener keypadActionListener, ActionListener buttonActionListener) {
        this.frameComponentListener = frameComponentListener;
        this.keypadActionListener = keypadActionListener;
        this.buttonActionListener = buttonActionListener;
    }

    public FrameComponentListener getFrameComponentListener() {
        return (FrameComponentListener) frameComponentListener;
    }
    public KeypadActionListener getKeypadActionListener() {
        return (KeypadActionListener) keypadActionListener;
    }
    public ButtonActionListener getButtonActionListener() {
        return (ButtonActionListener) buttonActionListener;
    }
}
