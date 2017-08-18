using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void SwitchToGameSceneStart()
	{
		SceneManager.LoadScene (0);
	}

	public void SwitchToGameSceneCampaign()
	{
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
		
	public void SwitchToGameSceneMapOverview()
	{
		SceneManager.LoadScene (5);
	}

	public void SwitchToGameSceneResults()
	{
		SceneManager.LoadScene (6);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
