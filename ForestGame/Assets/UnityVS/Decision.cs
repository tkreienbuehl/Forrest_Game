public class Decision {

    private int decisionID;
    private string decisionRequest;
    private byte industrialInfluence;
    private byte environmentalInfluence;
    private byte touristicInfluence;
    private short factionID;

    public Decision(int decisionID) {
        this.decisionID = decisionID;
    }

    public byte TouristicInfluence {
        get {
            return touristicInfluence;
        }

        set {
            touristicInfluence = value;
        }
    }

    public byte EnvironmentalInfluence {
        get {
            return environmentalInfluence;
        }

        set {
            environmentalInfluence = value;
        }
    }

    public byte IndustrialInfluence {
        get {
            return industrialInfluence;
        }

        set {
            industrialInfluence = value;
        }
    }

    public string DecisionRequest {
        get {
            return decisionRequest;
        }

        set {
            decisionRequest = value;
        }
    }

    public int getDecisionID() {
        return decisionID; 
    }

}