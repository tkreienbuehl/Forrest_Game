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
		StartCoroutine(DelaySceneLoad(1));
	}

	public void SwitchToGameSceneCampaignConservatives()
	{
		StartCoroutine(DelaySceneLoad(2));
	}

	public void SwitchToGameSceneCampaignDemocrats()
	{
		StartCoroutine(DelaySceneLoad(3));
	}

	public void SwitchToGameSceneCampaignEnvironmentalist()
	{
		StartCoroutine(DelaySceneLoad(4));
	}
		
	public void SwitchToGameSceneMapOverview()
	{
		SceneManager.LoadScene (5);
	}

	public void SwitchToGameSceneResults()
	{
		SceneManager.LoadScene (6);
	}

	public void SwitchToGameSceneIntro1()
	{
		StartCoroutine(DelaySceneLoad(7));
	}

	public void SwitchToGameSceneIntro2()
	{
		StartCoroutine(DelaySceneLoad(8));
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	IEnumerator DelaySceneLoad(int number)
	{
		yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene(number);
	}
}
