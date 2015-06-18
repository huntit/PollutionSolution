/* 
 * Door.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public Collider2D doorCollider2D;

	public void OpenDoor()
	{
		//Animate door
		doorCollider2D.enabled = false;
	}

	public void CloseDoor()
	{
		//Animate door
		doorCollider2D.enabled = true;
	}
}
