/* 
 * DoorTrigger.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
	public Door door;
	private float initialYHeight;

	private void Start()
	{
		initialYHeight = transform.position.y;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//Make the trigger go down
		transform.position = new Vector2(transform.position.x, initialYHeight - 0.05f);
		door.OpenDoor();
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		//Make the trigger go up
		transform.position = new Vector2(transform.position.x, initialYHeight);
		door.CloseDoor();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		//Make the trigger go down
		transform.position = new Vector2(transform.position.x, initialYHeight - 0.05f);
		door.OpenDoor();
	}

}
