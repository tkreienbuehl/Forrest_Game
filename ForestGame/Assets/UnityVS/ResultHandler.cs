using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultHandler : MonoBehaviour
{
	// the progress bars
    public Image environmental;
    public Image industry;
    public Image tourist;

	// the percentages of influence
	private float influenceEnvironment;
	private float influenceIndustry;
	private float influenceTourism;

    Influences influences;

	// the party values
	private Party party;

    void Start() {

        party = new Party();
        party.getBasicValue();

        environmental.fillAmount = party.getNature() / 100f;
        industry.fillAmount      = party.getIndustry() / 100f;
        tourist.fillAmount       = party.getTourism() / 100f;

		influenceEnvironment = environmental.fillAmount * 100;
		influenceIndustry    = industry.fillAmount * 100;
		influenceTourism     = tourist.fillAmount * 100;
    }

    void Update()
    {
        
    }

	public float GetInfluenceEnvironment(){
		return influenceEnvironment;
	}

	public float GetInfluenceIndustry(){
		return influenceIndustry;
	}

	public float GetInfluenceTourism(){
		return influenceTourism;
	}

	public bool IsReelected(){
		
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

	public void DebugResultsInfluence(){
		Debug.Log (influenceEnvironment.ToString());
		Debug.Log (influenceIndustry.ToString());
		Debug.Log (influenceTourism.ToString());
	}

	public void DebugResultsParty(Party party){
		Debug.Log (party.GetPartyName());
		Debug.Log (party.GetSlogan());
	}

}