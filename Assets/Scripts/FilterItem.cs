/* 
 * FilterItem.cs
 * By Max Finn
 * 
 * The filter parts which exist in-world, which on collection are lit up in the UI.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class FilterItem : MonoBehaviour {
	public FilterIcons filterIcon; // The matching UI icon for a filter part
	public AudioClip pickupSound;	// Sound to play when FilterItem picked up (Peter)

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Avatar"))
		{
			/*Added by Peter start*/
			// Play pickup sound
			if (pickupSound) 
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			/*Added by Peter end*/

			filterIcon.Collected = true;
			Destroy(gameObject);
		}
	}
}
