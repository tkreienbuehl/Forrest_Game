using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultHandler : MonoBehaviour
{
    public Image environmental;
    public Image industry;
    public Image tourist;

	private float influenceEnvironment;
	private float influenceIndustry;
	private float influenceTourism;

    Influences influences;

    void Start() {

        Party party = new Party();
        party.getBasicValue();

        environmental.fillAmount    = party.getNature();
        industry.fillAmount         = party.getIndustry();
        tourist.fillAmount          = party.getTourism();



		influenceEnvironment = environmental.fillAmount * 100;
		influenceIndustry    = industry.fillAmount * 100;
		influenceTourism     = tourist.fillAmount * 100;
    }

    void Update()
    {
        
    }

	public bool isReelected(){
		
		bool reelected = false;

		// checks if you are reelected
		if (influenceEnvironment > 51 && influenceIndustry > 51 && influenceTourism > 51) {
			reelected = true;
		}

		return reelected;
	}

    public void CalculateIndustrialInfluences(int influences)
    {
		influenceIndustry += influences;
		industry.fillAmount += influences / 100f;
    }

    public void CalculateEnvironmentalInfluences(int influences)
    {
		influenceEnvironment += influences;
        environmental.fillAmount += influences / 100f;
    }

    public void CalculateTouristInfluences(int influences)
    {
		influenceTourism += influences;
        tourist.fillAmount += influences / 100f;
    }

	public void DebugResults(){
		Debug.Log (influenceEnvironment.ToString());
		Debug.Log (influenceIndustry.ToString());
		Debug.Log (influenceTourism.ToString());
	}

}