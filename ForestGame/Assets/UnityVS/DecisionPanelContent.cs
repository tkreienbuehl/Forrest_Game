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
    public EnvironmentCalculator environmentCalculator;
    public MoneyHandler moneyHandler;

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
    public Sprite otherSprite;
    public Sprite medicineSprite;
    public Sprite fireFightSprite;

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
            environmentCalculator.setDecisionValue(rightInfluences.getEnvironmentalInfluence());
            //resultHandler.CalculateEnvironmentalInfluences(rightInfluences.getEnvironmentalInfluence());
            resultHandler.CalculateIndustrialInfluences(rightInfluences.getIndustrialInfluence());
            resultHandler.CalculateTouristInfluences(rightInfluences.getTouristicalInfluence());
            moneyHandler.ChangeMoneyAmount((float)rightInfluences.getCostInfluence());
            moneyHandler.ChangeMoneyAmount((float)rightInfluences.getCostYearlyInfluence());
        }
        else
        {
            iDecisionPanelObserver.setSelectedDecision((Int16)decisionIDLeft);
            environmentCalculator.setDecisionValue(leftInfluences.getEnvironmentalInfluence());
            resultHandler.CalculateEnvironmentalInfluences(leftInfluences.getEnvironmentalInfluence());
            resultHandler.CalculateIndustrialInfluences(leftInfluences.getIndustrialInfluence());
            resultHandler.CalculateTouristInfluences(leftInfluences.getTouristicalInfluence());
            moneyHandler.ChangeMoneyAmount((float)leftInfluences.getCostInfluence());
            moneyHandler.ChangeMoneyAmount((float)leftInfluences.getCostYearlyInfluence());
        }
    }

    public void SelectedSingleButton() {
        iDecisionPanelObserver.setSelectedDecision((Int16)decisionIDSingle);
        environmentCalculator.setDecisionValue(singleInfluences.getEnvironmentalInfluence());
        //resultHandler.CalculateEnvironmentalInfluences(singleInfluences.getEnvironmentalInfluence());
        resultHandler.CalculateIndustrialInfluences(singleInfluences.getIndustrialInfluence());
        resultHandler.CalculateTouristInfluences(singleInfluences.getTouristicalInfluence());
        moneyHandler.ChangeMoneyAmount((float)singleInfluences.getCostInfluence());
        moneyHandler.ChangeMoneyAmount((float)singleInfluences.getCostYearlyInfluence());
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
        if (imageNumber == 4)
        {
            return otherSprite;
        }
        if (imageNumber == 5)
        {
            return medicineSprite;
        }
        if (imageNumber == 6)
        {
            return fireFightSprite;
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
        if (factionNumber == 4)
        {
            return "Other";
        }
        if (factionNumber == 5)
        {
            return "Medicine";
        }
        if (factionNumber == 6)
        {
            return "FireFight";
        }

        return null;
    }
}
