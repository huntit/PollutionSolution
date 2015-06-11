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

	private static int currentLevel = 0;
	public static bool paused = false;
	
	//makes sure the HUD elements don't show on the start screen  - code for this is in Awake and Start
	void Awake()
	{
		//Keep this object alive in all scenes (Singleton)
	}

	void Start() 
	{
		PauseUI.SetActive(false);
		WinScreen.SetActive(false);
		LoseScreen.SetActive(false);
		//if Current Scene Name == "Start Game" (START SCREEN)
		//play start music
		//give option for quit
		//else if Current Scene Name starts with "Level", then (GAME LEVEL SCENE)
		//
		//Set FilterIcons.filterPartsCollected[0..3] to false
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
		Debug.Log ("Pausing");
		PauseUI.SetActive (true); // show Pause Panel
		Time.timeScale = 0; // pause game	}
	}

	public void ResumeGame()
	{
		Debug.Log("Resuming");
		PauseUI.SetActive (false); // hide Pause Panel
		Time.timeScale = 1; // restart
	}
								
	public void LoseGame()
	{
		Debug.Log("Losing");
		LoseScreen.SetActive(true);
		Time.timeScale = 0; 
//		Application.LoadLevel (currentLevel);

		//Load scene "Lose Game"
		//Display text to tell the Player they have lost
		//Show options for restart Game or Quit
					
		//	if Restart button is pressed
		//		set current Level = current Level
		//	if Quit button is pressed
		//		break all code and close the game
	}

	public void WinGame()
	{
		Debug.Log("Winning!");
		WinScreen.SetActive(true);
		Time.timeScale = 0;
		StartCoroutine("WaitForLevel");
		LoadNextLevel();

	}
												
	public void LoadNextLevel()
	{
		currentLevel = currentLevel + 1;
		Application.LoadLevel (currentLevel);
		//	Load Scene currentLevel
	}
	
	public void LevelCompleted()
	{
		//	If final level completed, 
		//	then load scene Win Screen
		//	Else if next level
		//	LoadNextLevel()
	}

	public void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false; //Stop when running in Editor
		Application.Quit (); //Stop when running for real
	}

	IEnumerator WaitforLevel() 
	{
		yield return new WaitForSeconds(5);
	}
}