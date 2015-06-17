using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	public Door door;
	private float initialYHeight;

	private void Start()
	{
		initialYHeight = transform.position.y;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//Animate trigger going down
		//transform.Translate (0f, -0.05f, 0f);
		transform.position = new Vector2(transform.position.x, initialYHeight - 0.05f);
		door.OpenDoor();
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		//Animate trigger going up
		//transform.Translate (0f, 0.05f, 0f);
		transform.position = new Vector2(transform.position.x, initialYHeight);
		door.CloseDoor();
	}
}
