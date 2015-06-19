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
	public AudioClip levelEndSound;		// sound to play when pollution has taken over the level

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

			// play clock ticking sound when time is running out
			int timeLeft = (int)(levelTime - i);
			if (timeLeft <= 30)
			{

				GameObject music = GameObject.FindGameObjectWithTag("MusicPlayer");
				if (music) { music.GetComponent<AudioSource>().volume = (timeLeft / 30f) * 0.5f; }	// fade out the music
				if (!GetComponent<AudioSource>().isPlaying) { GetComponent<AudioSource>().Play(); }	// play clock ticking sound effect

				// out of time - play level end sound
				if (timeLeft == 0 && levelEndSound) { AudioSource.PlayClipAtPoint(levelEndSound, transform.position, 1.0f); } 
			}
			else
			{
				GetComponent<AudioSource>().Stop();
			}

			yield return new WaitForSeconds(1);
		}

		if (!levelWon) { gameManager.LoseGame(); }
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