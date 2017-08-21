using System.Collections.Generic;
using UnityEngine;

public class DecisionController : MonoBehaviour, IDecisionPanelObserver {

    private IDecisionPool decisionPool;
    private float delay;
    private float actualTimeDelay;
    private DecisionPanelContent content;
    private bool waitingForAnswer;
    private List<IDecision> decisions;

    public void setSelectedAnswer(byte answerID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitingForAnswer = false;
    }

    public void setSelectedDecision(short decisionID) {
        foreach(IDecision dec in decisions) {
            if (dec.getDecisionID() == decisionID) {
                //TODO send the results to the bar controller
            }
        }        
        setNewRandomWaitTime();
        waitingForAnswer = false;
    }

    public void setDeniedDecision(short decisionID) {
        setNewRandomWaitTime();
        waitingForAnswer = false;
    }

    // Use this for initialization
    void Start () {
        decisionPool = DecisionPoolFactory.getDecisionPool();
        content = GameObject.Find("PanelCanvas").gameObject.GetComponent<DecisionPanelContent>();
        decisions = new List<IDecision>();
        content.RegisterObserver(this);
        setNewRandomWaitTime();
        waitingForAnswer = false;
	}
	
	// Update is called once per frame
	void Update () {
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
        delay = Random.Range(10.0f, max: 20.0f);
        actualTimeDelay = 0.0f;
    }

    private bool getSingleDecision() {
        return (Random.Range(1.0f, max: 100.0f) % 3 == 0);
    }
}
