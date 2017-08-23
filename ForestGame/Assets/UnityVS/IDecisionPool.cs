public interface IDecisionPool {

    Pair<IDecision, IDecision> getDecisionPair();

    IDecision getDecision();

    void setCostIsprotected(bool isProtected);

}
