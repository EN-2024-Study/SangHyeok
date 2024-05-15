package listener.repository;

import listener.ButtonListener;
import listener.ComponentListener;
import listener.KeypadListener;
import listener.PanelMouseListener;
import controller.CalculationManager;
import controller.ScreenManager;

public class ListenerRepository {

    private final ComponentListener componentListener;
    private final PanelMouseListener panelMouseListener;
    private final ButtonListener buttonListener;
    private final KeypadListener keypadListener;

    public ListenerRepository(ScreenManager screenManager, CalculationManager calculationManager) {
        this.componentListener = new ComponentListener(screenManager);
        this.panelMouseListener = new PanelMouseListener(screenManager);
        this.buttonListener = new ButtonListener(screenManager, calculationManager);
        this.keypadListener = new KeypadListener(screenManager, calculationManager);
    }

    public ComponentListener getComponentListener() {
        return componentListener;
    }

    public PanelMouseListener getPanelMouseListener() {
        return panelMouseListener;
    }

    public ButtonListener getButtonListener() {
        return buttonListener;
    }

    public KeypadListener getKeypadListener() {
        return keypadListener;
    }
}
