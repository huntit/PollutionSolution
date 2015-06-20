/* 
 * DoorTrigger.cs
 * By Max Finn
 * 
 * This script controls a button sitting on the ground, which is depressed when any other object enters its collider.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
	public Door door; // The door which a given trigger instance controls
	private float initialYHeight;

	private void Start()
	{
		// Store the triggers initial y value so multiple calls of OnTriggerStay2D
		// don't cause the trigger to sink into the ground
		initialYHeight = transform.position.y;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		// Make the trigger go up
		transform.position = new Vector2(transform.position.x, initialYHeight);
		door.CloseDoor();
	}

	private void OnTriggerStay2D(Collider2D other) // Peter made the swap from OnTriggerEnter2D to this, internal code is identical
	{
		// Make the trigger go down
		transform.position = new Vector2(transform.position.x, initialYHeight - 0.05f);
		door.OpenDoor();
	}
}
