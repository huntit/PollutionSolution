﻿using UnityEngine;
using System.Collections;

public class AirCanister : MonoBehaviour
{
	public AirBar airBar;
	public AudioClip pickupSound;	// sound to play when healthpack picked up

	private float airAmount = 10f;


	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
			airBar.Air += airAmount;
			// Play pickup sound
			if (pickupSound) 
			{ 
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			Destroy(gameObject);
		}
	}
}
