import java.util.ArrayList;
import java.util.List;

public class IObservable {

    private List<IObserver> observers;

    public IObservable() {
        observers = new ArrayList<IObserver>();
    }

    public void addObserver(IObserver o) {
        if (o != null&& !observers.contains(o)) {
            observers.add(o);
            return;
        }
        System.out.println("객체가 null 이거나 이미 생성됨.");
    }

    public void removeObserver(IObserver o) {
        if (o != null) {
            observers.remove(o);
            return;
        }
        System.out.println("객체가 존재하지 않음.");
    }

    public void notifyObservers(Object arg) {
        for(IObserver o : observers) {
            o.update(this, arg);
        }
    }
}
