/* 
 * LevelPollution.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelPollution : MonoBehaviour
{
	private float alphaVal;
	public float levelTime = 180f;
	public static bool levelWon = false;
	public GameManager gameManager;

	// Use this for initialization
	private void Start()
	{
		StartCoroutine("FadeScreen");
	}

	public IEnumerator FadeScreen()
	{
		for (int i = 0; i <= levelTime && !levelWon; i++)
		{
			alphaVal = Mathf.Pow((i / levelTime), 2f);
			gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, alphaVal);
			yield return new WaitForSeconds(1);
		}
		if (!levelWon) {	gameManager.LoseGame(); }
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

// https://drive.google.com/file/d/0B-Rw4HNsjfjFV1JKZmZzMW1wbFE/view?usp=sharing