public class EventPoolFactory {

    private EventPoolFactory() {

    }

    public static IEventPool GetEventPool() {
        return new EventPool();
    }
}
