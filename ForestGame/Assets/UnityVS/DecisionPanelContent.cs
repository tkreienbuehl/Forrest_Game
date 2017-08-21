using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanelContent : MonoBehaviour
{
    public GameObject canvas;

    public IDecisionPanelObserver iDecisionPanelObserver;
    public AnimationManagerPanels animationManagerPanels;
    public ResultHandler resultHandler;

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

    public GameObject panelSingleGameObject;
    public Text singlePanelText;
    public Image imageSingle;
    public int decisionIDSingle;
    public int factionIDSingle;

    private Influences leftInfluences;
    private Influences rightInfluences;
    private Influences singleInfluences;


    public void SetDecisionPair(IDecision leftDecision, IDecision rightDecision)
    {
        factionIDLeft = rightDecision.getFactionID();
        decisionIDLeft = rightDecision.getDecisionID();
        textLeft.text = rightDecision.getRequestText();
        //imageLeft = rightDecision.getImage();
        leftInfluences = rightDecision.getInfluences();

        factionIDRight = leftDecision.getFactionID();
        decisionIDRight = leftDecision.getDecisionID();
        textRight.text = leftDecision.getRequestText();
        rightInfluences = leftDecision.getInfluences();
        //imageRight = leftDecision.getImage();
        animationManagerPanels.ShowPanel("MultipleDecisionsPanelAnimation");
    }

    public void SetDecision(IDecision decision)
    {
        decisionIDSingle = decision.getDecisionID();
        factionIDSingle = decision.getDecisionID();
        singlePanelText.text = decision.getRequestText();
        singleInfluences = decision.getInfluences();
        //singleImage = decision.getImage();
        animationManagerPanels.ShowPanel("SingleDecisionPanelAnimation");
    }

    public void SelectedButton(bool isRight)
    {
        if (isRight)
        {
            iDecisionPanelObserver.setSelectedDecision((Int16)decisionIDRight);
            resultHandler.CalculateEnvironmentalInfluences(rightInfluences.getEnvironmentalInfluence());
            resultHandler.CalculateIndustrialInfluences(rightInfluences.getIndustrialInfluence());
            resultHandler.CalculateTouristInfluences(rightInfluences.getTouristicalInfluence());
        }
        else
        {
            iDecisionPanelObserver.setSelectedDecision((Int16)decisionIDLeft);
            resultHandler.CalculateEnvironmentalInfluences(leftInfluences.getEnvironmentalInfluence());
            resultHandler.CalculateIndustrialInfluences(leftInfluences.getIndustrialInfluence());
            resultHandler.CalculateTouristInfluences(leftInfluences.getTouristicalInfluence());
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
