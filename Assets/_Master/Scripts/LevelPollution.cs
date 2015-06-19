/* 
 * LevelPollution.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class LevelPollution : MonoBehaviour
{
	public float alphaVal, levelTime;
	public GameManager gameManager;

	// Use this for initialization
	private void Start()
	{
		StartCoroutine("FadeScreen");
	}

	private IEnumerator FadeScreen()
	{
		for (int i = 0; i < levelTime; i++)
		{
			alphaVal = Mathf.Pow((i / levelTime), 2f);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphaVal);
			yield return new WaitForSeconds(1);
		}
		gameManager.LoseGame();
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