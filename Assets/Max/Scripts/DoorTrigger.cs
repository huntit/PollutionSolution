using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	public Door door;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		//Animate trigger going down
		door.OpenDoor();
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		//Animate trigger going up
		door.CloseDoor();
	}
}
