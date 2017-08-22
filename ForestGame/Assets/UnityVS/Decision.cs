public class Decision : IDecision {

    private int decisionID;
    private string decisionRequest;
    Influences influences;
    private short factionID;
    private short actionID;

    public Decision(int decisionID) {
        this.decisionID = decisionID;
        influences = new Influences();
        factionID = 0;
        decisionRequest = "";
        actionID = 0;
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

    public short getActionID() {
        return actionID;
    }

    public void setActionID(short actionID) {
        this.actionID = actionID;
    }
}