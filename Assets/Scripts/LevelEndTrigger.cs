/* 
 * LevelEndTrigger.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour
{
	public GameManager gameManager;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar") && FilterIcons.filterCount >= 4)
		{
			LevelPollution.levelWon = true;
			gameManager.WinGame();
		}
	}
}
