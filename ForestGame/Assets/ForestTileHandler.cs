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

    public float burningTime = 6f;

    public Renderer[] Renderers
	{
		get;
		private set;
	}

	public Color CurrentColor
	{
		get { return _currentColor; }
	}

	private List<Material> _materials = new List<Material>();
	private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
		Renderers = GetComponentsInChildren<Renderer>();

		foreach (var renderer in Renderers)
		{	
			_materials.AddRange(renderer.materials);
		}
	}

	private void OnMouseEnter()
	{
        if(!ClickerEventHandler.IsClickEventActive)
        {
            return;
        }

		_targetColor = GlowColor;
		enabled = true;
	}

	private void OnMouseExit()
	{
        _targetColor = Color.clear;
		enabled = true;
	}

    private void OnMouseDown()
    {

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
        }

        if(transform.tag == "Selective Forest" && ClickerEventHandler.IsClickEventActive && ClickerEventHandler.currentCuttingType == CuttingType.SelectiveCut)
        {
            GameObject newForest;
            Destroy(transform.GetChild(0).gameObject);

            newForest = Instantiate(selectiveFab, transform.position, transform.rotation);
            transform.tag = "Selective Forest";

            newForest.transform.SetParent(transform);

            ClickerEventHandler.amountOfForestCut++;
        }
    }

    /// <summary>
    /// Loop over all cached materials and update their color, disable self if we reach our target color.
    /// </summary>
    private void Update()
	{
		_currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		for (int i = 0; i < _materials.Count; i++)
		{
			_materials[i].SetColor("_Color", _currentColor);
		}

		if (_currentColor.Equals(_targetColor))
		{
			enabled = false;
		}        
    }

    public void StartFire()
    {
        //Instantiate fire

        Invoke("EndFire", burningTime);
    }

    private void EndFire()
    {
        //Delete fire

        GameObject newForest;

        Destroy(transform.GetChild(0).gameObject);

        // Should be burned forest
        newForest = Instantiate(selectiveFab, transform.position, transform.rotation);
        transform.tag = "Selective Forest";

        newForest.transform.SetParent(transform);
    }
}
