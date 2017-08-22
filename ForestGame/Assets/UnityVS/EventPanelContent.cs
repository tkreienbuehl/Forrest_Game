using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.UI;

public class EventPanelContent : MonoBehaviour
{
    private IEventPanelObserver iEventPanelObserver;
    public AnimationManagerPanels animationManagerPanels;

    int eventID;
    short factionID;
    public Text eventText;

    public void SetEvent(IEvent iEvent)
    {
        eventText.text = iEvent.getEventText();
        eventID = iEvent.getEventID();
        factionID = iEvent.getFactionID();

        animationManagerPanels.ShowPanel("EventPanelAnimation");
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
