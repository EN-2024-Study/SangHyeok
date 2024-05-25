package interfaces;

public interface IObservable {
    void addObserver(IObserver o);
    void notifyObservers(String arg);
    void run();
}
