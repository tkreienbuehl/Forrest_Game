using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour, IEventPanelObserver {

    private IEventPool eventPool;
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

    public void setDeniedDecision(short decisionID) {
        //TODO use the results
        setNewRandomWaitTime();
    }

    // Use this for initialization
    void Start() {
        eventPool = EventPoolFactory.getEventPool();
    }

    // Update is called once per frame
    void Update() {
        actualTimeDelay += Time.deltaTime;
        if (actualTimeDelay >= delay) {
            IEvent ievent = eventPool.getEvent();
            
        }
    }

    private void setNewRandomWaitTime() {
        delay = Random.Range(100.0f, max: 300.0f);
        actualTimeDelay = 0.0f;
    }

    public void setEventCommited() {
        //TODO
        setNewRandomWaitTime();
    }


}
