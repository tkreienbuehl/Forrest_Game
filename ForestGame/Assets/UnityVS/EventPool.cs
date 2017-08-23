public class EventPool : IEventPool {

    public EventPool() {

    }

    public IEvent getEvent() {
        // TODO replace stub by real implementation
        Event eventStub = new Event(1);
        Influences infl = new Influences();
        infl.setEnvironmentalInfluence(5);
        infl.setIndustrialInfluence(0);
        infl.setTouristicalInfluence(0);
        eventStub.setInfluences(infl);
        eventStub.setEventText("A forest fire has occured.");
        eventStub.setFactionID(0);
        return eventStub;
    }
}
