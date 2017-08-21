public interface IDecision {

    Influences getInfluences(int nrOfAnswer = 0);

    int getDecisionID();

    short getFactionID();

    string getRequestText();

    float getIncome();

    float getYearlyCosts();

}
