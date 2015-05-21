using UnityEngine;
using System.Collections;

public class FilterItem : MonoBehaviour {
	public int filterID;
	public FilterIcons filterIcons;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Avatar"))
		{
			//filterIcons.filterPartsCollected[filterID] = true;
			//filterIcons.DrawFilterPartsCollected();
			// Play pickup sound
			Destroy(gameObject);
		}
	}
}
