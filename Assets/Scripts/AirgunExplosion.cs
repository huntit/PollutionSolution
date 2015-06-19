/*
 * AirgunExplosion.cs
 * by Peter Hunt 
 *
 * Script to play particle system on start and destroy it on completion
*/

using UnityEngine;
using System.Collections;

public class AirgunExplosion : MonoBehaviour 
{
	//	Play particle system on start and destroy it after duration
	void Start() 
	{
		ParticleSystem explosion = GetComponent<ParticleSystem>();
		explosion.Play();
		Destroy(gameObject, explosion.duration);	// automatically destroy the particle system 
	}

}
