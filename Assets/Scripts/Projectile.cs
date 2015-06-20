/*
 * Projectile.cs
 * by Peter Hunt 
 * 
 * Script to control avatar projectile - ie. sound effects, collision with enemy and destroy on impact
 */

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public AudioClip firingSound;				// sound to play when projectile is fired
	public AudioClip impactSound;				// sound to play when projectile hits
	public float projectileLifespan = 0.3f;		// give the projectile a lifespan before auto-destroy

	private void Start()
	{
		// automatically destroy the projectile after a short time span
		Destroy(gameObject, projectileLifespan);
	}

	// Destroy the projectile and play an impact sound effect if it collides with anything except the avatar
	// If it collides with the enemy, reduce the pollution for the level, and reduce the particle emission rate
	void OnCollisionEnter2D(Collision2D target) 
	{	
		// Destroy projectile when it collides with anything except the avatar
		if (target.gameObject.tag != "Avatar")
		{
			Destroy(gameObject);
			if (impactSound) { AudioSource.PlayClipAtPoint(impactSound, transform.position); }
		}

		// Collided with enemy - reduce the pollution
		if (target.gameObject.tag == "Enemy")
		{
			ParticleSystem particles = target.gameObject.GetComponentInChildren<ParticleSystem>();
			if (particles) 
			{ 
				// Add some time to the level, and reduce the pollution
				LevelPollution levelPollution = GameObject.FindObjectOfType<LevelPollution>() as LevelPollution;
				if (particles.emissionRate >= 1f && levelPollution) { levelPollution.levelTime += 3.0f; }
				particles.emissionRate = particles.emissionRate / 2f; 	// reduce the particle emission rate
			}
		}
	}

}
