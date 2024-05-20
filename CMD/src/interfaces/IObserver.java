package interfaces;

import observable.CmdManager;

public interface IObserver {
    void update(CmdManager o, String arg);
}
