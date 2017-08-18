public class Decision : IDecision {

    private int decisionID;
    private string decisionRequest;
    Influences influences;
    private short factionID;

    public Decision(int decisionID) {
        this.decisionID = decisionID;
    }

    public void setRequestText(string text) {
        decisionRequest = text;
    }

    public void setFactionID(short id) {
        factionID = id;
    }

    public void setInfluences(Influences influences) {
        this.influences = influences;
    }

    public int getDecisionID() {
        return decisionID; 
    }

    public short getFactionID() {
        return factionID;
    }

    public Influences getInfluences(int nrOfAnswer = 0) {
        return influences;
    }

    public string getRequestText() {
        return decisionRequest;
    }
}