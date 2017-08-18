﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionController : MonoBehaviour, IDecisionPanelObserver {

    private IDecisionPool decisionPool;
    private float delay;
    private float actualTimeDelay;

    public void setSelectedAnswer(byte answerID) {
        //TODO use the results
        setNewRandomWaitTime();
    }

    public void setSelectedDecision(short decisionID) {
        //TODO use the results
        setNewRandomWaitTime();
    }

    // Use this for initialization
    void Start () {
        decisionPool = DecisionPoolFactory.getDecisionPool();
	}
	
	// Update is called once per frame
	void Update () {
        actualTimeDelay += Time.deltaTime;
        if (actualTimeDelay >= delay) {
            //TODO give decision to DecisionPanelClass
            decisionPool.getDecisionPair();
        }
	}

    private void setNewRandomWaitTime() {
        delay = Random.Range(10.0f, max: 20.0f);
        actualTimeDelay = 0.0f;
    }
}