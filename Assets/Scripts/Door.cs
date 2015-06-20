/* 
 * Door.cs
 * By Max Finn
 * 
 * The door controlled by this script is red when closed, and green when open, and is unlocked by a linked DoorTrigger.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public Collider2D doorCollider2D;
	private Color doorRed = new Color(0.871f, 0.211f, 0.211f);
	private Color doorGreen = new Color (0.211f, 0.871f, 0.211f);

	public void OpenDoor()
	{
		// Make door green and allow other objects to pass through it
		gameObject.GetComponent<SpriteRenderer>().color = doorGreen;
		doorCollider2D.enabled = false;
	}

	public void CloseDoor()
	{
		// Make door red and prevent other objects from passing through it
		gameObject.GetComponent<SpriteRenderer>().color = doorRed;
		doorCollider2D.enabled = true;
	}
}
