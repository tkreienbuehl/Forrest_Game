using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanelContent : MonoBehaviour
{
    public GameObject canvas;

    private IDecisionPanelObserver iDecisionPanelObserver;

    public GameObject panelRightGameObject;
    public Text textRight;
    public Image imageRight;
    public int decisionIDRight;
    public int factionIDRight;

    public GameObject panelLeftGameObject;
    public Text textLeft;
    public Image imageLeft;
    public int decisionIDLeft;
    public int factionIDLeft;

    public GameObject singlePanelGameObject;
    public Text singlePanelText;
    public Image singleImage;
    public int decisionIDSingle;
    public int factionIDSingle;

    public AnimationManagerPanels animationManagerPanels;

    public void SetDecisionPair(IDecision leftDecision, IDecision rightDecision)
    {
        factionIDLeft = leftDecision.getFactionID();
        decisionIDLeft = leftDecision.getDecisionID();
        textLeft.text = leftDecision.getRequestText();
        //imageLeft = leftDecision.getImage();

        factionIDRight = rightDecision.getFactionID();
        decisionIDRight = rightDecision.getDecisionID();
        textRight.text = rightDecision.getRequestText();
        //imageRight = rightDecision.getImage();
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
