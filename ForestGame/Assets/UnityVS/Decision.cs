public class Decision : IDecision {

    private int decisionID;
    private string decisionRequest;
    Influences influences;
    private short factionID;
    private float income;
    private float yearlyCosts;
    private short actionID;

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

    public void setIncome(float income) {
        this.income = income;
    }

    public void setYearlyCosts(float costs) {
        yearlyCosts = costs;
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

    public float getIncome() {
        return income;
    }

    public float getYearlyCosts() {
        return yearlyCosts;
    }
}