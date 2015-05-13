using UnityEngine;
using System.Collections;

public class LevelPollution : MonoBehaviour {
	//GameObject gameObject;

	// Use this for initialization
	void Start () {
		//StartCoroutine (FadeScreen ());
		Color color = GetComponent<Renderer>().material.color;
		color.a = 0.9f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeScreen()
	{
		Color color = GetComponent<Renderer>().material.color;
		color.a = 0.5f;
		yield return new WaitForSeconds(1);
	}
}

/*
 * This script makes the level progressively obscured by pollution (a black quad)
 * over the course of five minutes, at which point the screen is completely covered and the player will lose.
 * 
 * int secondsElapsed = 0
 * int totalSecondsAllowed = 300
 * Start()
 * Call FadeScreen() coroutine
 *
 * Update()
 * if secondsElapsed >= totalSecondsAllowed, call GameManager.LoseGame()
 *
 * IEnumerator FadeScreen()
 * Set opacity of quad to min(secondsElapsed/totalSecondsAllowed, 1),
 * increase secondsElapsed by 1, and then wait one second before repeating
 */