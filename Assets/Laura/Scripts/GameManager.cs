using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private static int currentLevel = 0;
	// Use this for initialization
	
	//makes sure the HUD elements don't show on the start screen  - code for this is in Awake and Start
	void Awake()
	{
		//Keep this object alive in all scenes (Singleton)
	}

	void Start () 
	{
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
	
	}		
							
	public void PauseGame()
	{
		//Overlay text to show screen is paused
		//time.Scale = 0
	}
								
	public void ResumeGame()
	{
		//delete overlay text
		//time.Scale = 1
	}
								
	public void LoseGame()
	{
		//Load scene "Lose Game"
		//Display text to tell the Player they have lost
		//Show options for restart Game or Quit
					
		//	if Restart button is pressed
		//		set current Level = current Level
		//	if Quit button is pressed
		//		break all code and close the game
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
}