using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	public AudioClip firingSound;	// sound to play when projectile is fired
	public AudioClip impactSound;	// sound to play when projectile hits

	void OnCollisionEnter2D(Collision2D target) 
	{
		
		// Destroy when it collides with anything except the player
		if (target.gameObject.tag != "Player")
		{
			if (impactSound) 
			{ 
				AudioSource.PlayClipAtPoint(impactSound, transform.position);
			}
			Destroy(gameObject);
		}
	}

}
