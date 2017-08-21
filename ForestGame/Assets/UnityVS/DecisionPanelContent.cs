using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanelContent : MonoBehaviour
{
    private GameObject canvas;

    private IDecisionPanelObserver iDecisionPanelObserver;

    GameObject panelRightGameObject;
    Text textRight;
    Image imageRight;
    int decisionIDRight;
    int factionIDRight;

    GameObject panelLeftGameObject;
    Text textLeft;
    Image imageLeft;
    int decisionIDLeft;
    int factionIDLeft;


    public void SetDecisionPair(IDecision leftDecision, IDecision rightDecision)
    {
        factionIDLeft = rightDecision.getFactionID();
        decisionIDLeft = rightDecision.getDecisionID();
        textLeft.text = rightDecision.getRequestText();
        //imageLeft = rightDecision.getImage();

        factionIDRight = leftDecision.getFactionID();
        decisionIDRight = leftDecision.getDecisionID();
        textRight.text = leftDecision.getRequestText();
        //imageRight = leftDecision.getImage();
        animationManagerPanels.ShowPanel("MultipleDecisionsPanelAnimation");
    }

    public void SetDecision(IDecision decision)
    {
        decisionIDSingle = decision.getDecisionID();
        factionIDSingle = decision.getDecisionID();
        singlePanelText.text = decision.getRequestText();
        //singleImage = decision.getImage();
        animationManagerPanels.ShowPanel("SingleDecisionPanelAnimation");
    }

    public void SelectedButton(bool isRight)
    {
        if (isRight)
        {
            iDecisionPanelObserver.setSelectedDecision((Int16)decisionIDRight);
        }
        else
        {
            iDecisionPanelObserver.setSelectedDecision((Int16)decisionIDLeft);
        }
    }

    public void DeniedDecision()
    {
        iDecisionPanelObserver.setDeniedDecision((Int16)decisionIDRight);
    }

    public void RegisterObserver(IDecisionPanelObserver iDecisionPanelObserver)
    {
        this.iDecisionPanelObserver = iDecisionPanelObserver;
    }
}
