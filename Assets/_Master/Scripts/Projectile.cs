using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	public AudioClip firingSound;	// sound to play when projectile is fired
	public AudioClip impactSound;	// sound to play when projectile hits

	void OnCollisionEnter2D(Collision2D target) 
	{

		// Destroy when it collides with anything except the player
		if (target.gameObject.tag != "Avatar")
		{
			if (impactSound) 
			{ 
				AudioSource.PlayClipAtPoint(impactSound, transform.position);
			}
			Destroy(gameObject);
		}
	}


	// remove particles from the world on collision with the air gun projectile
	void OnParticleCollision(GameObject other)
	{
		ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
	
//		ParticleSystem.Particle[] points;
//		particleSystem.GetParticles(points);

		Debug.Log ("Particles: " + particleSystem.particleCount);

		/**
		MyParticleSystem mySystem = other.GetComponent<MyParticleSystem>();
		if(null != mySystem)
		{
			//here we will get the particle list from the attached MyParticleSystem
			ParticleSystem.Particle[] points = mySystem.GetParticleList();
			
			ParticleCollisionEvent[] collisions = new ParticleCollisionEvent[particleSystem.GetSafeCollisionEventSize()];
			int numberOfCollisions = particleSystem.GetCollisionEvents(this.gameObject, collisions);
			int j = 0;    
			
			while(j < numberOfCollisions)
			{
				//find the particle closest to the collision
				Vector3 collisionLocation = collisions[j].intersection;
				float closestDistanceToIntersect = float.MaxValue;
				int closestParticleNumber = -1;
				for(int i = 0; i < this.points.Length; i++)
				{
					ParticleSystem.Particle p = points[i];
					float distanceFromIntersect = Vector3.Distance(p.position, collisionLocation);
					if(distanceFromIntersect < closestDistanceToIntersect)
					{
						closestDistanceToIntersect = distanceFromIntersect;
						closestParticleNumber = i;
					}            
				}
				//I am pretty sure lifetime has to be set to less than 0.0f to get rid of it
				
				points[closestParticleNumber].lifetime = -1;
				
			}
			//assign the list back to the object
			mySystem.SetParticleList(points);
		}
		**/
	}



}
