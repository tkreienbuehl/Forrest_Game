public class EventAndDecisionLocker {

    private bool lockEvents;
    private bool lockDecisions;

    private static EventAndDecisionLocker instance = null;

    private EventAndDecisionLocker() {
        lockEvents = false;
        lockDecisions = false;
    }

    public static EventAndDecisionLocker getInstance() {
         if (instance == null) {
            instance = new EventAndDecisionLocker();
        }
        return instance;
    }

    public bool getEventsLocked() {
        return lockEvents;
    }

    public bool getDecisionsLocked() {
        return lockDecisions;
    }

    public void lockAllEvents() {
        lockEvents = true;
    }

    public void lockAllDecisions() {
        lockDecisions = true;
    }

    public void unlockAllEvents() {
        lockEvents = false;
    }

    public void unlockAllDecisions() {
        lockDecisions = false;
    }
}