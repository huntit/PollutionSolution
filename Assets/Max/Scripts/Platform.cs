using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
	// Transform startPosition, endPosition;
	public float moveTime;
	private bool travelBackwards = false;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		// startPosition = this.GetComponent<GameObject>().Transform; // Investigate proper phrasing
		rb.AddForce (-100f *Vector2.right);
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		 * Move platform (from startPosition to endPosition) over moveTime,
		 * then once there, do the same in the opposite direction
		 * If it isn't built in to RigidBody2D, add a force to colliders immediately
		 * above the Platform to keep them on top of it as it moves
		 */
	}
}
