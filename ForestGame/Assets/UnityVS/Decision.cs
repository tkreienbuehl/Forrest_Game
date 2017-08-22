public class Decision : IDecision {

    private int decisionID;
    private string decisionRequest;
    Influences influences;
    private short factionID;
    private short actionID;
    private short nrOfFieldsAffected;
    private bool isBribe;

    public Decision(int decisionID) {
        this.decisionID = decisionID;
        influences = new Influences();
        factionID = 0;
        decisionRequest = "";
        actionID = 0;
        nrOfFieldsAffected = 0;
        isBribe = false;
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

    public void setNrOfFieldsAffected(short nr) {
        nrOfFieldsAffected = nr;
    }

    public void setIsBribe(bool bribe) {
        isBribe = bribe;
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

    public short getNrOfAffectedFields() {
        return nrOfFieldsAffected;
    }

    public bool getIsBribe() {
        return isBribe;
    }
}