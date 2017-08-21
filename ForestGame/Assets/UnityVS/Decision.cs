public class Decision : IDecision {

    private int decisionID;
    private string decisionRequest;
    Influences influences;
    private short factionID;
    private short income;

    public Decision(int decisionID) {
        this.decisionID = decisionID;
        income = 0;
        influences = new Influences();
        factionID = 0;
        decisionRequest = "";
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