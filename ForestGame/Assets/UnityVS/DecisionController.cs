using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionController : MonoBehaviour, IDecisionPanelObserver
{

    public GameObject JailGameObject;

    private IDecisionPool decisionPool;
    private float delay;
    private float actualTimeDelay;
    private DecisionPanelContent content;
    private bool waitingForAnswer;
    private List<IDecision> decisions;
    private byte speedUpFactor;
    public ClickerEventHandler handler;
    private bool avoidClearCut;
    public ResultHandler resHandler;
    public MoneyHandler moneyHandler;
    EventAndDecisionLocker locker;
    public EnvironmentCalculator calculator;

    private enum actionIDs {
        SELECTIVE_CUT = 1,
        CLEAR_CUT = 2,
        AVOID_CLEAR_CUT = 3,
        PROTECT_COSTLINE = 4,
    }

    public void setSelectedAnswer(byte answerID) {
        waitingForAnswer = false;
        locker.unlockAllEvents();
        //TODO use the results
        setNewRandomWaitTime();
    }

    public void setSelectedDecision(short decisionID) {
        waitingForAnswer = false;
        foreach (IDecision dec in decisions) {
            if (dec.getDecisionID() == decisionID) {
                if (dec.getActionID() == (short)actionIDs.SELECTIVE_CUT) {
                    handler.StartClickEvent(CuttingType.SelectiveCut, dec.getNrOfAffectedFields());
                }
                if (dec.getActionID() == (short)actionIDs.CLEAR_CUT) {
                    if (avoidClearCut) {
                        resHandler.CalculateEnvironmentalInfluences(-20);
                        avoidClearCut = false;
                    }
                    handler.StartClickEvent(CuttingType.ClearCut, dec.getNrOfAffectedFields());
                }
                if (dec.getActionID() == (short)actionIDs.AVOID_CLEAR_CUT) {
                    avoidClearCut = true;
                }
                if (dec.getActionID() == (short)actionIDs.PROTECT_COSTLINE) {
                    decisionPool.setCostIsprotected(true);
                    //TODO call the event
                }
                if (dec.getIsBribe()) {
                    double nr = Random.Range(1.0f, max: 100.0f);
                    if ((int)nr % 2 == 0) {
                        // you are busted and go to jail
						JailGameObject.SetActive(true);
                    }
                }
                moneyHandler.ChangeMoneyAmount((float)dec.getInfluences().getIncomeInfluence());
                moneyHandler.ChangeYearlyCostAmount(-(float)dec.getInfluences().getCostYearlyInfluence());
            }
        }
        locker.unlockAllEvents();
        setNewRandomWaitTime();
    }

    public void setDeniedDecision(short decisionID) {
        waitingForAnswer = false;
        setNewRandomWaitTime();
    }

    // Use this for initialization
    void Start () {
        waitingForAnswer = false;
        speedUpFactor = 2;
        decisionPool = DecisionPoolFactory.getDecisionPool();
        content = GameObject.Find("PanelCanvas").gameObject.GetComponent<DecisionPanelContent>();
        decisions = new List<IDecision>();
        content.RegisterObserver(this);
        locker = EventAndDecisionLocker.getInstance();
        setNewRandomWaitTime();
	}
	
	// Update is called once per frame
	void Update () {
        actualTimeDelay += Time.deltaTime;
        if (actualTimeDelay >= delay  && !waitingForAnswer && !locker.getDecisionsLocked()) {
            waitingForAnswer = true;
            decisions.Clear();
            locker.lockAllEvents();
            if (getSingleDecision()) {
                IDecision desc = decisionPool.getDecision();
                decisions.Add(desc);
                content.SetDecision(desc);
            }
            else {
                Pair<IDecision, IDecision> pair = decisionPool.getDecisionPair();
                decisions.Add(pair.getKey());
                decisions.Add(pair.getValue());
                content.SetDecisionPair(pair.getKey(), pair.getValue());
            }
		}
	}

    private void setNewRandomWaitTime() {
        delay = Random.Range(10.0f / speedUpFactor, max: 20.0f / speedUpFactor);
        actualTimeDelay = 0.0f;
    }

    private bool getSingleDecision() {
        double nr = Random.Range(1.0f, max: 100.0f);
        return ((int)nr % 5 == 0);
    }
}
