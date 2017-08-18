public interface IDecisionPanelObserver {

    void setSelectedDecision(short decisionID);

    void setDeniedDecision(short decisionID);

    void setSelectedAnswer(byte answerID);

}
