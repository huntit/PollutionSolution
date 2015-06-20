/* 
 * HealthPack.cs
 * By Max Finn
 * 
 * A pickup item which increases the player's health by a fixed amount.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour
{
	public HealthBar healthBar;
	public AudioClip pickupSound;	// sound to play when healthpack picked up

	[Range(1, 20)] public float healthAmount = 10f;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
			healthBar.Health += healthAmount;
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
