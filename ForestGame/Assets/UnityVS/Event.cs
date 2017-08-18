public class Event : IEvent {

    private int eventID;
    private string eventText;
    Influences influences;
    private short factionID;

    public Event(int eventID) {
        this.eventID = eventID;
    }

    public void setEventText(string text) {
        eventText = text;
    }

    public void setFactionID(short id) {
        factionID = id;
    }

    public void setInfluences(Influences influences) {
        this.influences = influences;
    }

    public int getEventID() {
        return eventID;
    }

    public short getFactionID() {
        return factionID;
    }

    public Influences getInfluences() {
        return influences;
    }

    public string getEventText() {
        return eventText;
    }

}
