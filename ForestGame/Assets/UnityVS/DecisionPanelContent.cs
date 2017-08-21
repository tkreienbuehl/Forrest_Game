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
        canvas = GameObject.Find("PanelCanvas");
        panelRightGameObject = canvas.transform.Find("RightPanel").gameObject;
        textRight = panelRightGameObject.transform.Find("Panel").transform.Find("DecisionDescription").GetComponent<Text>();
        panelLeftGameObject = canvas.transform.Find("LeftPanel").gameObject;
        textLeft = panelRightGameObject.transform.Find("DecisionDescription").GetComponent<Text>();

        factionIDLeft = leftDecision.getFactionID();
        decisionIDLeft = leftDecision.getDecisionID();
        textLeft.text = leftDecision.getRequestText();
        //imageLeft = leftDecision.getImage();

        factionIDRight = rightDecision.getFactionID();
        decisionIDRight = rightDecision.getDecisionID();
        textRight.text = rightDecision.getRequestText();
        //imageRight = rightDecision.getImage();
    }

    public void SetDecision(IDecision decision)
    {
        canvas = GameObject.Find("PanelCanvas");
        panelRightGameObject = canvas.transform.Find("SingleDecisionPanel").gameObject;
        textRight = panelRightGameObject.transform.Find("Panel").transform.Find("DecisionDescription").GetComponent<Text>();

        factionIDRight = decision.getFactionID();
        decisionIDRight = decision.getDecisionID();
        textRight.text = decision.getRequestText();
        //imageRight = rightDecision.getImage();
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
