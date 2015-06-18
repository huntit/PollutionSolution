/*
 * Projectile.cs
 * by Peter Hunt 
 * 
 * Script to control projectile - ie. sound effect, and destroy on impact
 */

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public AudioClip firingSound;	// sound to play when projectile is fired
	public AudioClip impactSound;	// sound to play when projectile hits
	public float projectileLifespan = 0.3f;		// give the projectile a lifespan of 0.3 seconds

	private void Start()
	{
		// automatically destroy the projectile after a short time span
		Destroy(gameObject, projectileLifespan);
	}

	void OnCollisionEnter2D(Collision2D target) 
	{
		// Destroy when it collides with anything except the player
		if (target.gameObject.tag != "Avatar")
		{
			if (impactSound) { AudioSource.PlayClipAtPoint(impactSound, transform.position); }
			Destroy(gameObject);
		}
	}

}
