public class DecisionExample {

    public Decision Decision1() {
        return DecisionExp(1, 1, "We want to clearcut 4 fields of old forest. \n Income: 10000K, 11000K if labeled", InfluenceExp(-5, 5, -2), 1, 4);
    }
    public Decision Decision2() {
        return DecisionExp(2, 2, "Clearcut? That will keep our guests away! Please choose selective cut!. \n Income: 6000K, 6600K if labeled", InfluenceExp(-2, -2, 2));
    }

    public Decision SingleDecision() {
        return DecisionExp(3, 4, "Mayor, let us build a more modern hospital to increase health level in town", InfluenceExp(3, 3, 3));
    }

    Decision DecisionExp(short decisionID, short factionId, string requestText, Influences infl, short eventID = 0, short nrOfFields = 0) {
        Decision decision;
        decision = new Decision(decisionID);
        decision.setInfluences(infl);
        decision.setRequestText(requestText);
        decision.setFactionID(factionId);
        decision.setActionID(eventID);
        decision.setNrOfFieldsAffected(nrOfFields);
        return decision;
    }

    Influences InfluenceExp(short envInfluence, short indInfluence, short touInfluence) {
        Influences influences = new Influences();
        influences.setEnvironmentalInfluence(envInfluence);
        influences.setIndustrialInfluence(indInfluence);
        influences.setTouristicalInfluence(touInfluence);
        influences.setCostInfluence(10000);
        return influences;
    }
}