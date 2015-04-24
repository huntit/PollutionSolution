using UnityEngine;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour {
	private bool allFilterPartsCollected;
	public FilterIcons filterIcons;
	public GameManager gameManager;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
			allFilterPartsCollected = true;
			foreach(bool filterPart in filterIcons.filterPartsCollected)
			{
				if (!filterPart) { allFilterPartsCollected = false; }
			}
			if (allFilterPartsCollected) { gameManager.LevelCompleted(); }
		}
	}
}
