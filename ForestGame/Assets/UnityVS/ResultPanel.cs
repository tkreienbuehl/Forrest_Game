using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour {

	private Party party;
	private ResultHandler resultHandler;

	public Text party_result;
	public Text slogan_result;
	// public Text money_result;
	public Text inf_env_result;
	public Text inf_ind_result;
	public Text inf_tou_result;

	void Start()
	{
		party = new Party ();
		resultHandler = new ResultHandler ();

		// add the result to the text objects
		party_result.text = party.GetPartyName();
		slogan_result.text = party.GetSlogan ();
		inf_env_result.text = resultHandler.GetInfluenceEnvironment().ToString()+"%";
		inf_ind_result.text = resultHandler.GetInfluenceIndustry().ToString()+"%";
		inf_tou_result.text = resultHandler.GetInfluenceTourism().ToString()+"%";
	}
}
