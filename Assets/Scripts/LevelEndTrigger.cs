/* 
 * LevelEndTrigger.cs
 * By Max Finn
 * 
 * When the player runs through this with all filter parts collected, they clear the level.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour
{
	public GameManager gameManager;

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Make sure it's the player going through the trigger, and that they have all four filter parts
		if (other.CompareTag("Avatar") && FilterIcons.filterCount >= 4)
		{
			LevelPollution.levelWon = true; // Stop pollution from darkening screen further
			gameManager.WinGame();
		}
	}
}
