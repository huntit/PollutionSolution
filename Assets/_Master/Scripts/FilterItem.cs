using UnityEngine;
using System.Collections;

public class FilterItem : MonoBehaviour {
//	public int filterID;
	public FilterIcons filterIcon;
	public AudioClip pickupSound;	// sound to play when filteritem picked up

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Avatar"))
		{
			//filterIcons.filterPartsCollected[filterID] = true;
			//filterIcons.DrawFilterPartsCollected();
			filterIcon.Collected = true;

			// Play pickup sound
			if (pickupSound) 
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			Destroy(gameObject);
		}
	}
}
