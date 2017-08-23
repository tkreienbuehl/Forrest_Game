using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionController : MonoBehaviour, IDecisionPanelObserver {

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

	private float electionTime = 0;

    public void setSelectedAnswer(byte answerID) {
        waitingForAnswer = false;
        //TODO use the results
        setNewRandomWaitTime();
    }

    public void setSelectedDecision(short decisionID) {
        waitingForAnswer = false;
        foreach (IDecision dec in decisions) {
            if (dec.getDecisionID() == decisionID) {
                if (dec.getActionID() == 1) {
                    handler.StartClickEvent(CuttingType.SelectiveCut, dec.getNrOfAffectedFields());
                }
                if (dec.getActionID() == 2) {
                    if (avoidClearCut) {
                        resHandler.CalculateEnvironmentalInfluences(-20);
                        avoidClearCut = false;
                    }
                    handler.StartClickEvent(CuttingType.ClearCut, dec.getNrOfAffectedFields());
                }
                if (dec.getActionID() == 3) {
                    avoidClearCut = true;
                }
                if (dec.getIsBribe()) {
                    double nr = Random.Range(1.0f, max: 100.0f);
                    if ((int)nr % 4 == 0) {
                        //TODO set jail event
                    }
                }
            }
        }        
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
        setNewRandomWaitTime();
	}
	
	// Update is called once per frame
	void Update () {
		
		// the countdown until the elections
		electionTime += Time.deltaTime;

		// triggers the elections after a certain amount of time
		if (electionTime > 30) {

			bool isReelected = content.resultHandler.isReelected();

			// triggers reelected UI based on influence
			if (isReelected) {
				SceneManager.LoadScene (9);
			} else {
				SceneManager.LoadScene (10);
			}
		}

        actualTimeDelay += Time.deltaTime;
        if (actualTimeDelay >= delay  && !waitingForAnswer) {
            waitingForAnswer = true;
            decisions.Clear();
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
