using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.UI;

public class EventPanelContent : MonoBehaviour
{
    private IEventPanelObserver iEventPanelObserver;

    private GameObject canvas;
    private int eventID;
    private short factionID;
    private Text eventText;

    private GameObject eventPanel;

    public void SetEvent(IEvent iEvent)
    {
        canvas = GameObject.Find("PanelCanvas");
        eventPanel = canvas.transform.Find("EventPanel").gameObject;
        eventText = eventPanel.transform.Find("Panel").transform.Find("EventDescription").GetComponent<Text>();

        eventText.text = iEvent.getEventText();
        eventID = iEvent.getEventID();
        factionID = iEvent.getFactionID();
    }

    public void AcceptEvent()
    {
        iEventPanelObserver.setEventCommited();
    }

    public void RegisterObserver(IEventPanelObserver iEventPanelObserver)
    {
        this.iEventPanelObserver = iEventPanelObserver;
    }
}
