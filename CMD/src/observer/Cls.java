package observer;

import controller.ExceptionManager;
import interfaces.IObserver;
import observable.Cmd;

public class Cls implements IObserver {

    private ExceptionManager exceptionManager;

    public Cls(ExceptionManager exceptionManager) {
        this.exceptionManager = exceptionManager;
    }

    @Override
    public void update(Cmd cmd, String command) {
        if (!exceptionManager.isClsValid(command)) {
            return;
        }

        for (int i = 0; i < 100; i++) {
            System.out.println("\b");
        }
    }
}

