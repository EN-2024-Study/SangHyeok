package observable;

public interface IObservable {
    void addObserver(IObserver o);
    void notifyObservers(String arg);
}
