using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTileHandler : MonoBehaviour {

	public Color GlowColor;
	public float LerpFactor = 10;
    public GameObject clearCutFab;
    public GameObject selectiveFab;
    public GameObject treeFab;
    public GameObject treeFabManaged;
    public GameObject BurnedForest;
    public GameObject fires;

    public float burningTime = 6f;

    public Material WWFLogo;
    private bool isProtectedForest;

    private GameObject currentFire;


	public Color CurrentColor
	{
		get { return _currentColor; }
	}


	private Color _currentColor;
	private Color _targetColor;


    public void ChangeToProtectedForest()
    {
        isProtectedForest = true;
        GetComponent<MeshRenderer>().material = WWFLogo;
    }

	private void OnMouseEnter()
	{
        if(!ClickerEventHandler.IsClickEventActive)
        {
            return;
        }

		_targetColor = GlowColor;
	}

	private void OnMouseExit()
	{
        _targetColor = Color.clear;
	}

    private void OnMouseDown()
    {
        if (isProtectedForest)
            return;

        if ((transform.tag == "Old Forest" || transform.tag == "Managed Forest") && ClickerEventHandler.IsClickEventActive)
        {
            GameObject newForest;
            Destroy(transform.GetChild(0).gameObject);

            if (ClickerEventHandler.currentCuttingType == CuttingType.SelectiveCut)
            {
                newForest = Instantiate(selectiveFab, transform.position, transform.rotation);
                transform.tag = "Selective Forest";
            }
            else
            {
                newForest = Instantiate(clearCutFab, transform.position, transform.rotation);
                transform.tag = "Clear Cut Forest";
            }

            newForest.transform.SetParent(transform);

            ClickerEventHandler.amountOfForestCut++;
        } else if(transform.tag == "Selective Forest" && ClickerEventHandler.IsClickEventActive && ClickerEventHandler.currentCuttingType == CuttingType.SelectiveCut)
        {
            GameObject newForest;
            Destroy(transform.GetChild(0).gameObject);

            newForest = Instantiate(clearCutFab, transform.position, transform.rotation);
            transform.tag = "Clear Cut Forest";

            newForest.transform.SetParent(transform);

            ClickerEventHandler.amountOfForestCut++;
        }
    }

    /// <summary>
    /// Loop over all cached materials and update their color, disable self if we reach our target color.
    /// </summary>
    private void Update()
	{
        if (!_currentColor.Equals(_targetColor))
        {
            _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

            GetComponent<MeshRenderer>().material.SetColor("_Color", _currentColor);
        }
    }

    public void StartFire()
    {
        Destroy(currentFire);

        //Instantiate fire
        currentFire = Instantiate(fires, transform.position, transform.rotation);

        Invoke("EndFire", burningTime);
    }

    private void EndFire()
    {
        //Delete fire
        Destroy(currentFire);

        GameObject newForest;

        Destroy(transform.GetChild(0).gameObject);

        // Should be burned forest
        newForest = Instantiate(BurnedForest, transform.position, transform.rotation);
        transform.tag = "Burned Forest";

        newForest.transform.SetParent(transform);
    }
}
