﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionController : MonoBehaviour, IDecisionPanelObserver {

    private IDecisionPool decisionPool;
    private float delay;
    private float actualTimeDelay;
    private DecisionPanelContent content;
    private bool waitingForAnswer; 

    public void setSelectedAnswer(byte answerID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitingForAnswer = false;
    }

    public void setSelectedDecision(short decisionID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitingForAnswer = false;
    }

    public void setDeniedDecision(short decisionID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitingForAnswer = false;
    }

    // Use this for initialization
    void Start () {
        decisionPool = DecisionPoolFactory.getDecisionPool();
        content = GameObject.Find("PanelCanvas").gameObject.GetComponent<DecisionPanelContent>();
        content.RegisterObserver(this);
        setNewRandomWaitTime();
        waitingForAnswer = false;
	}
	
	// Update is called once per frame
	void Update () {
        actualTimeDelay += Time.deltaTime;
        if (actualTimeDelay >= delay  && !waitingForAnswer) {
            waitingForAnswer = true;
            Pair<IDecision, IDecision> pair = decisionPool.getDecisionPair();
            content.SetDecisionPair(pair.getKey(), pair.getValue());
        }
	}

    private void setNewRandomWaitTime() {
        delay = Random.Range(10.0f, max: 20.0f);
        actualTimeDelay = 0.0f;
    }
}
