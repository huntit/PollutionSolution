/* 
 * LevelPollution.cs
 * By Max Finn
 * 
 * A representation of the pollution in the level, which worsens faster as time goes on.
 * Once the level turns completely black, the player automatically loses.
 * 
 */ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelPollution : MonoBehaviour
{
	private float alphaVal;
	public float levelTime = 180f; // How long the level can go for in seconds.
	public static bool levelWon = false;
	public GameManager gameManager;
	public AudioClip levelEndSound;		// sound to play when pollution has taken over the level (Peter)

	// Use this for initialization
	private void Start()
	{
		StartCoroutine("FadeScreen");
	}

	// Gradually ramps up the opacity of the black pollution square until the entire screen is pure black, and the player loses
	public IEnumerator FadeScreen()
	{
		for (int i = 0; i <= levelTime && !levelWon; i++)
		{
			// Makes the darkness exponential towards the end of the level, and keeps visibilty high during the start
			alphaVal = Mathf.Pow((i / levelTime), 2f);
			gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, alphaVal);

			/*Added by Peter start*/
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
			/*Added by Peter end*/

			yield return new WaitForSeconds(1); // Change the darkness only once per second
		}

		if (!levelWon) { gameManager.LoseGame(); } // Prevents loss during the "You Won!" screen
	}
}
