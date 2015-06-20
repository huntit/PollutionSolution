/* 
 * FilterItem.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class FilterItem : MonoBehaviour {
	public FilterIcons filterIcon;
	public AudioClip pickupSound;	// Sound to play when FilterItem picked up

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Avatar"))
		{
			// Play pickup sound
			if (pickupSound) 
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			Destroy(gameObject);

			filterIcon.Collected = true;
		}
	}
}
