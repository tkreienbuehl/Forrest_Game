using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour {

	private string intro_1 = "Hello!";
	private string intro_2 = "We need a new mayor for our town.";
	private string intro_3 = "You are a talented candidate.";
	private string intro_4 = "How will you campaign?";
	private string intro_5 = "Good luck!";
	private string intro_6 = "I see you are ready to get some work done.";
	private string intro_7 = "There are high expectations of you. Don't disappoint us.";
	private string intro_8 = "My advice is to keep the stakeholders happy.";
	private string intro_9 = "Lets roll!";

	private Text text;
	private int count;

	// Use this for initialization
	void Start () {
		count = 1;
		text = this.GetComponent<Text> ();
		StartCoroutine (AnimateText (intro_1));
	}
		
	public void NextLineIntro1(){
		switch (count) {
		case 1:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_2));
			break;
		case 2:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_3));
			break;
		case 3:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_4));
			break;
		case 4:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_5));
			break;
		}
		count++;
	}

	public void NextLineIntro2(){
		switch (count) {
		case 1:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_6));
			break;
		case 2:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_7));
			break;
		case 3:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_8));
			break;
		case 4:
			this.text.text = "";
			StartCoroutine (AnimateText (intro_9));
			break;
		}
		count++;
	}

	public IEnumerator AnimateText(string line){
		int i = 0;
		while (i < line.Length) {
			this.text.text += line [i++];
			yield return new WaitForSeconds (0.02F);
		}
	}
		
}
