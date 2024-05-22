package interfaces;

import observable.Cmd;

public interface IObserver {
    void update(Cmd o, String arg);
}
