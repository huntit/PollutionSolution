using UnityEngine;
using System.Collections;

public class FilterItem : MonoBehaviour {
	public int filterID;
	public FilterIcons filterIcons;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
			filterIcons.filterPartsCollected[filterID] = true;
			filterIcons.DrawFilterPartsCollected();
			// Play pickup sound
			Destroy(gameObject);
		}
	}
}
