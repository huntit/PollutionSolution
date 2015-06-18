using UnityEngine;
using System.Collections;

public class AirgunExplosion : MonoBehaviour 
{
	void Start() 
	{
		var exp = GetComponent<ParticleSystem>();
		exp.Play();
		Destroy(gameObject, exp.duration);	// automatically destroy the particle system 
	}

}
