package model;

import observer.ButtonListener;
import observer.KeypadListener;
import observer.FrameComponentListener;

import java.awt.event.ActionListener;

public class ListenerVo {

    private KeypadListener keypadListener;
    private FrameComponentListener frameComponentListener;
    private ButtonListener buttonListener;

    public ListenerVo(FrameComponentListener frameComponentListener, ButtonListener buttonListener, KeypadListener keypadListener) {
        this.frameComponentListener = frameComponentListener;
        this.buttonListener = buttonListener;
        this.keypadListener = keypadListener;
    }

    public FrameComponentListener getFrameComponentListener() {
        return frameComponentListener;
    }
    public KeypadListener getKeypadListener() {
        return keypadListener;
    }

    public ButtonListener getButtonListener() {
        return buttonListener;
    }
}
