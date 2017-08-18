public class EventPool : IEventPool {

    public EventPool() {

    }

    public IEvent getEvent() {
        Event eventStub = new Event(1);
        Influences infl = new Influences();
        infl.setEnvironmentalInfluence(10);
        infl.setIndustrialInfluence(0);
        infl.setTouristicalInfluence(0);
        eventStub.setInfluences(infl);
        eventStub.setEventText("Your forrest company has just receivt FSC label.");
    }
}
