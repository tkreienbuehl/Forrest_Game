using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void SwitchToGameSceneCampaignConservatives()
	{
		SceneManager.LoadScene (1);
	}

	public void SwitchToGameSceneCampaignDemocrats()
	{
		SceneManager.LoadScene (2);
	}

	public void SwitchToGameSceneCampaignEnvironmentalist()
	{
		SceneManager.LoadScene (3);
	}
}
