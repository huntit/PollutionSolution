﻿using UnityEngine;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour {
	public GameManager gameManager;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar") && FilterIcons.filterCount == 4)
		{
			gameManager.WinGame();
		}
	}
}
