/* 
 * HealthPack.cs
 * By Max Finn
 * 
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
			// Play pickup sound
			if (pickupSound)
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			Destroy(gameObject);
		}
	}
}
