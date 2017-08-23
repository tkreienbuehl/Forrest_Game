using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentCalculator : MonoBehaviour
{
    public Transform grid;
    public Image enviromentProgress;
    private List<GameObject> forestBlocks = new List<GameObject>();

    private int amountClearCut;
    private int amountSelectiveCut;
    private int amountOldForest;
    private int amountManagedForest;

    private float clearCutValue;
    private float selectiveCutValue;
    private float oldForestValue;
    private float managedForestValue;

    private float amountOfForest;
    private float decisionValue;

	// Use this for initialization
	void Start () {

	    foreach (Transform child in transform)
	    {
	        forestBlocks.Add(child.gameObject);
	    }

	    amountOfForest = forestBlocks.Count;

	    clearCutValue = (amountOfForest / 100f) * 0f;
	    selectiveCutValue = (amountOfForest / 100f) * 0.045f;
	    oldForestValue = (amountOfForest / 100f) * 0.09f;
	    managedForestValue = (amountOfForest / 100f) * 0.035f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    foreach (GameObject forestBlock in forestBlocks)
	    {
	        CheckTag(forestBlock.tag);
	    }

        SetEnvironmentBar(CalculateValue());
	}

    void CheckTag(string tag)
    {
        if (tag == "Old Forest")
        {
            amountOldForest++;
        }
        if (tag == "Managed Forest")
        {
            amountManagedForest++;
        }
        if (tag == "Clear Cut Forest")
        {
            amountClearCut++;
        }
        if (tag == "Selective Forest")
        {
            amountSelectiveCut++;
        }
    }

    float CalculateValue()
    {
        float value = 0;
        value += amountClearCut * clearCutValue;
        value += amountManagedForest * managedForestValue;
        value += amountSelectiveCut * selectiveCutValue;
        value += amountOldForest * oldForestValue;
        value += decisionValue;

        Debug.Log(value);
        return value;
    }

    void SetEnvironmentBar(float value)
    {
        enviromentProgress.fillAmount = value;

        amountManagedForest = 0;
        amountOldForest = 0;
        amountClearCut = 0;
        amountSelectiveCut = 0;
    }

    public void setDecisionValue(int value)
    {
        decisionValue = (float)value / 100f;
    }
    
    public void StartForestFire()
    {
        List<GameObject> possibleBlocks = new List<GameObject>();

        foreach (GameObject forestBlock in forestBlocks)
        {
            if(forestBlock.tag == "Old Forest" || forestBlock.tag == "Managed Forest")
            {

                possibleBlocks.Add(forestBlock);

            }
        }

        possibleBlocks[Random.Range(0, possibleBlocks.Count)].GetComponent<ForestTileHandler>().StartFire();
    }
}
