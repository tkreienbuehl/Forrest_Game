using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour, IEventPanelObserver {

    private IEventPool eventPool;
    private float delay;
    private float actualTimeDelay;
    private bool waitForAnswer;
    private EventPanelContent content;

    public void setSelectedAnswer(byte answerID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitForAnswer = false;
    }

    public void setSelectedDecision(short decisionID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitForAnswer = false;
    }

    public void setDeniedDecision(short decisionID) {
        //TODO use the results
        setNewRandomWaitTime();
        waitForAnswer = false;
    }

    // Use this for initialization
    void Start() {
        content = GameObject.Find("PanelCanvas").gameObject.GetComponent<EventPanelContent>();
        eventPool = EventPoolFactory.getEventPool();
        setNewRandomWaitTime();
    }

    // Update is called once per frame
    void Update() {
        actualTimeDelay += Time.deltaTime;
        if (actualTimeDelay >= delay && !waitForAnswer) {
            waitForAnswer = true;
            IEvent ievent = eventPool.getEvent();
            content.SetEvent(ievent);
        }
    }

    private void setNewRandomWaitTime() {
        delay = Random.Range(40.0f, max: 75.0f);
        actualTimeDelay = 0.0f;
    }

    public void setEventCommited() {
        //TODO give the influences to the bar controller
        setNewRandomWaitTime();
    }


}
