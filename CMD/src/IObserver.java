import java.util.Observable;
import java.util.Observer;

public interface IObserver {
    void update(IObservable o, Object arg);
}
