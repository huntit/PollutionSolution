using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour
{
	public HealthBar healthBar;
	public AudioClip pickupSound;	// sound to play when healthpack picked up

	private float healthAmount = 20f;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
			healthBar.Health += healthAmount;
			// Play pickup sound
			if (pickupSound) 
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			Destroy(gameObject);
		}
	}
}
