package model;

import observer.ButtonListener;
import observer.KeypadListener;
import observer.ComponentListener;
import observer.PanelMouseListener;

public class ListenerVo {

    private KeypadListener keypadListener;
    private ComponentListener componentListener;
    private ButtonListener buttonListener;
    private PanelMouseListener panelMouseListener;

    public ListenerVo(ComponentListener componentListener, ButtonListener buttonListener, KeypadListener keypadListener, PanelMouseListener panelMouseListener) {
        this.componentListener = componentListener;
        this.buttonListener = buttonListener;
        this.keypadListener = keypadListener;
        this.panelMouseListener = panelMouseListener;
    }

    public ComponentListener getComponentListener() {
        return componentListener;
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
