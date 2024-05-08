package model;

import observer.ButtonListener;
import observer.KeypadListener;
import observer.FrameComponentListener;
import observer.PanelMouseListener;

import java.awt.event.ActionListener;

public class ListenerVo {

    private KeypadListener keypadListener;
    private FrameComponentListener frameComponentListener;
    private ButtonListener buttonListener;
    private PanelMouseListener panelMouseListener;

    public ListenerVo(FrameComponentListener frameComponentListener, ButtonListener buttonListener, KeypadListener keypadListener, PanelMouseListener panelMouseListener) {
        this.frameComponentListener = frameComponentListener;
        this.buttonListener = buttonListener;
        this.keypadListener = keypadListener;
        this.panelMouseListener = panelMouseListener;
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
    public PanelMouseListener getPanelMouseListener() {
        return panelMouseListener;
    }
}
