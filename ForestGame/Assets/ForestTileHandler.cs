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
        GameObject gameObject;
        if (transform.tag == "Old Forest")
        {
            Destroy(transform.GetChild(0).gameObject);
            gameObject = Instantiate(selectiveFab, transform.position, transform.rotation);
            gameObject.transform.SetParent(transform);
            transform.tag = "Selective Forest";
        }
        else if (transform.tag == "Managed Forest")
        {
            Destroy(transform.GetChild(0).gameObject);
            gameObject = Instantiate(clearCutFab, transform.position, transform.rotation);
            gameObject.transform.SetParent(transform);
            transform.tag = "Clear Cut Forest";
        }
        else if (transform.tag == "Selective Forest")
        {
            Destroy(transform.GetChild(0).gameObject);
            gameObject = Instantiate(clearCutFab, transform.position, transform.rotation);
            gameObject.transform.SetParent(transform);
            transform.tag = "Clear Cut Forest";
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
}
