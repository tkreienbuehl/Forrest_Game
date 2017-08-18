public class EventPoolFactory {

    private EventPoolFactory() {

    }

    public static IEventPool getEventPool() {
        return new EventPool();
    }
}
