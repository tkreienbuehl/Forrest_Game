using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void SwitchToGameSceneCampaign()
	{
		Debug.Log ("called");
		SceneManager.LoadScene (1);
	}

	public void SwitchToGameSceneCampaignConservatives()
	{
		SceneManager.LoadScene (2);
	}

	public void SwitchToGameSceneCampaignDemocrats()
	{
		SceneManager.LoadScene (3);
	}

	public void SwitchToGameSceneCampaignEnvironmentalist()
	{
		SceneManager.LoadScene (4);
	}
		
	public void QuitGame()
	{
		Application.Quit();
	}
}
