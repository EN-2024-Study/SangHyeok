package model;

import observer.ButtonActionListener;
import observer.FrameComponentListener;

import java.awt.event.ActionListener;

public class ListenerVo {

    private ActionListener buttonActionListener;
    private FrameComponentListener frameComponentListener;

    public ListenerVo(FrameComponentListener frameComponentListener, ButtonActionListener buttonActionListener) {
        this.frameComponentListener = frameComponentListener;
        this.buttonActionListener = buttonActionListener;
    }

    public FrameComponentListener getFrameComponentListener() {
        return (FrameComponentListener) frameComponentListener;
    }
    public ButtonActionListener getButtonActionListener() {
        return (ButtonActionListener) buttonActionListener;
    }
}
