/* 
 * GameManager Script by Laura Yarnold
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject PauseUI;
	public GameObject WinScreen;
	public GameObject LoseScreen;
	public AvatarController avatar;

	private static int currentLevel = 0;
	public static bool paused = false;
	private bool gameOver = false;

	void Start() 
	{
		PauseUI.SetActive(false);
		WinScreen.SetActive(false);
		LoseScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Pause")) 
		{ 
			if (paused) 
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
			paused = !paused;
		}
	}		
							
	public void PauseGame()
	{
		PauseUI.SetActive (true); // show Pause Panel
		Time.timeScale = 0; // pause game
	}

	public void ResumeGame()
	{
		PauseUI.SetActive (false); // hide Pause Panel
		Time.timeScale = 1; // restart
	}
								
	public void LoseGame()
	{
		if (!gameOver)
		{
			gameOver = true;
			avatar.Die();	// play avatar dying sound
			LoseScreen.SetActive(true);
//		Time.timeScale = 0;
			StartCoroutine ("WaitForLevel", 1);
		}
	}

	public void WinGame()
	{
		WinScreen.SetActive(true);
//		Time.timeScale = 0;
		StartCoroutine("WaitForLevel", 0);

	}
												
	public void LoadNextLevel()
	{
		currentLevel = currentLevel + 1;
		Application.LoadLevel (currentLevel);
	}

	public void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false; //Stop when running in Editor
		Application.Quit (); //Stop when running for real
	}

	IEnumerator WaitForLevel(int level) 
	{
		yield return new WaitForSeconds(4);
		Debug.Log (level);
		Application.LoadLevel(level);
		Time.timeScale = 1;

	}
}