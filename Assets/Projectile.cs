using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D target) 
	{
		
		// Destroy when it collides with anything except the player
		if (target.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}

}
