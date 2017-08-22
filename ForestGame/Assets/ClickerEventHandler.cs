using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerEventHandler : MonoBehaviour {

    public static bool IsClickEventActive = false;
    public static int amountOfForestCut = 0;
    public static CuttingType currentCuttingType = CuttingType.ClearCut;

    private int totalCurrentFieldsNeeded;


    public void StartClickEvent(CuttingType cuttingType, int amountOfFields)
    {
        currentCuttingType = cuttingType;
        totalCurrentFieldsNeeded = amountOfFields;
        IsClickEventActive = true;
    }

    void Update()
    {
        if(amountOfForestCut >= totalCurrentFieldsNeeded)
        {
            // End event
            IsClickEventActive = false;
            amountOfForestCut = 0;
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            StartClickEvent(CuttingType.SelectiveCut, 4);
        }
    }
}

public enum CuttingType
{
    ClearCut, SelectiveCut
}
