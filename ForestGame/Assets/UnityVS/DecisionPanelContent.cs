﻿using System;
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
    public Text typeRight;
    public Image imageRight;
    public int decisionIDRight;
    public int factionIDRight;

    public GameObject panelLeftGameObject;
    public Text textLeft;
    public Text typeLeft;
    public Image imageLeft;
    public int decisionIDLeft;
    public int factionIDLeft;

    public GameObject panelSingleGameObject;
    public Text singlePanelText;
    public Text singleTypeText;
    public Image imageSingle;
    public int decisionIDSingle;
    public int factionIDSingle;

    private Influences leftInfluences;
    private Influences rightInfluences;
    private Influences singleInfluences;

    public Sprite touristSprite;
    public Sprite EnvironmentalSprite;
    public Sprite IndustrialSprite;


    public void SetDecisionPair(IDecision leftDecision, IDecision rightDecision)
    {
        factionIDLeft = rightDecision.getFactionID();
        decisionIDLeft = rightDecision.getDecisionID();
        textLeft.text = rightDecision.getRequestText();
        typeLeft.text = SelectText(rightDecision.getFactionID());
        imageLeft.sprite = SelectImage(rightDecision.getFactionID());
        leftInfluences = rightDecision.getInfluences();

        factionIDRight = leftDecision.getFactionID();
        decisionIDRight = leftDecision.getDecisionID();
        textRight.text = leftDecision.getRequestText();
        typeRight.text = SelectText(leftDecision.getFactionID());
        rightInfluences = leftDecision.getInfluences();
        imageRight.sprite = SelectImage(leftDecision.getFactionID());
        animationManagerPanels.ShowPanel("MultipleDecisionsPanelAnimation");
    }

    public void SetDecision(IDecision decision)
    {
        decisionIDSingle = decision.getDecisionID();
        factionIDSingle = decision.getDecisionID();
        singlePanelText.text = decision.getRequestText();
        singleTypeText.text = SelectText(decision.getFactionID());
        singleInfluences = decision.getInfluences();
        imageSingle.sprite = SelectImage(decision.getFactionID());
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

    private Sprite SelectImage(int imageNumber)
    {
        if (imageNumber == 1)
        {
            return IndustrialSprite;
        }

        if (imageNumber == 2)
        {
            return touristSprite;
        }
        if (imageNumber == 3)
        {
            return EnvironmentalSprite;
        }

        return null;
    }

    private string SelectText(int factionNumber)
    {
        if (factionNumber == 1)
        {
            return "Industry";
        }
        if (factionNumber == 2)
        {
            return "Tourism";
        }
        if (factionNumber == 3)
        {
            return "Environment";
        }

        return null;
    }
}