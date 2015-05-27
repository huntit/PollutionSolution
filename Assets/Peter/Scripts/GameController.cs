/* 
 * GameController Script by Laura Yarnold
 * 
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public static bool paused = false;
	public Image pauseBackground;

	void Start() 
	{

	}


	void Update() 
	{ 
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			if (paused) 
			{
				Debug.Log ("Resuming");
				pauseBackground.enabled = false; // hide Pause Panel
				Time.timeScale = 1; // restart
			}
			else
			{
				Debug.Log ("Pausing");
				pauseBackground.enabled = true; // show Pause Panel

				Time.timeScale = 0; // pause game
			}
     		paused = !paused;
		}
	 }


}



