/* 
 * AirCanister.cs
 * By Max Finn
 * 
 * A pickup item which increases the player's air by a fixed amount.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class AirCanister : MonoBehaviour
{
	public AirBar airBar;
	public AudioClip pickupSound;	// sound to play when healthpack picked up (Peter)

	[Range(0, 25)] public float airAmount = 15f;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
			airBar.Air += airAmount;
			/*Added by Peter start*/
			// Play pickup sound
			if (pickupSound) 
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			/*Added by Peter end*/
			Destroy(gameObject); // Remove pickup from level
		}
	}
}
