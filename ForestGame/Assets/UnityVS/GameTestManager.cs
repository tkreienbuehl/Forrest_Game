﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Test class to run the scene in a short amount of time.
 **/

public class GameTestManager : MonoBehaviour {

	public float time = 0;
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > 5) {
			SceneManager.LoadScene (6);
		}
	}
}
