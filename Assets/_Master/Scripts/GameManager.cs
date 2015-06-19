/* 
 * GameManager Script by Laura Yarnold
 * 
 * Manages all UI elements/screens in the game.
 */ 

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	// Creates access to a public UI game object - Pause UI 
	public GameObject PauseUI;

	// Creates access to a public UI game object - Win Screen 
	public GameObject WinScreen;

	// Creates access to a public UI game object - Lose Screen
	public GameObject LoseScreen;

	// Sets the Avatar contoller to be avatar
	public AvatarController avatar;

	// Sets the current level to be 0 (the main screen)
	private static int currentLevel = 0;

	// Makes sure the game is not paused
	public static bool paused = false;

	// Makes sure the game does not display 'Game Over' settings
	private bool gameOver = false;

	//Sets all menu options to be set to false (eg Pause UI, Win Screen, Lose Screen)
	void Start() 
	{
		PauseUI.SetActive(false);
		WinScreen.SetActive(false);
		LoseScreen.SetActive(false);
	}
	
	// Sets up condtions for pausing and resuming the game; switches between pause and resume
	void Update() 
	{
		if (Input.GetButtonDown("Pause")) 
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

	//Method Pause Game sets the UI element PauseUI to be shown on screen, and sets time to be frozen
	public void PauseGame()
	{
		PauseUI.SetActive (true); // Shows Pause Panel
		Time.timeScale = 0; // Pause game
	}

	// Hides the UI element PauseUI, and resets time to resume gameplay
	public void ResumeGame()
	{
		PauseUI.SetActive (false); // Hides Pause Panel
		Time.timeScale = 1; // Restart game
	}

	/* If gameOver is called, the avatar dies, the Lose Screen UI is activated, a co-routine is started to keep 
	 * the LoseScreen alive for 4 seconds and sends a call to 'Wait For Level' function.*/
	public void LoseGame()
	{
		if (!gameOver)
		{
			gameOver = true;
			avatar.Die();	// Plays avatar dying sound
			LoseScreen.SetActive(true);
			StartCoroutine ("WaitForLevel", 1);
		}
	}

	/* If WinGame is called, the WinSceen UI is activated, and a co-routine is started to keep 
	 * the WinScreen alive for 4 seconds, and sends a call to 'Wait For Level' function.*/
	public void WinGame()
	{
		WinScreen.SetActive(true);
		StartCoroutine("WaitForLevel", 0);
	}

	// LoadNextLevel is used to transition from the Start Menu to the first game level.
	public void LoadNextLevel()
	{
		currentLevel = currentLevel + 1;
		Application.LoadLevel (currentLevel);
	}


	// Quits the game; is used in the Start Menu and Pause Menu.
	public void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false; //Stop when running in Editor
		Application.Quit (); //Stop when running for real
	}

	/* WaitForLevel receives an interger from either the WinScreen or LoseScreen, waits for 4 seconds, 
	 * loads the appropriate level from the integer received (from 'level'), and sets the timescale to 1.*/
	IEnumerator WaitForLevel(int level) 
	{
		yield return new WaitForSeconds(4);
		Application.LoadLevel(level);
		Time.timeScale = 1;

	}
}