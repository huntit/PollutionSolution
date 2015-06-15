using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
	public float speed = 4f;
	private float startTime;
	private float journeyLength;
	private bool travelForwards = false;
	public Transform pointA, pointB;

	// Use this for initialization
	void Start ()
	{
		transform.position = pointA.position;
		startTime = Time.time;
		journeyLength = Vector3.Distance(pointA.position, pointB.position);
	}

	void FixedUpdate()
	{
		/*
		 * Move platform (from startPosition to endPosition) over moveTime,
		 * then once there, do the same in the opposite direction
		 * If it isn't built in to RigidBody2D, add a force to colliders immediately
		 * above the Platform to keep them on top of it as it moves
		 */
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = (travelForwards) ? distCovered / journeyLength : (journeyLength - distCovered) / journeyLength;
		GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.forward * Time.deltaTime);

		transform.position = Vector3.Lerp (pointA.position, pointB.position, fracJourney);
		if (fracJourney <= 0 || fracJourney >= 1)
		{
			travelForwards = !travelForwards;
			startTime = Time.time;
		}
	}

	// If an object collides with the trigger at the top of the platform, make it move with the platform
	void OnTriggerEnter2D(Collider2D collider)
	{
		collider.transform.parent = gameObject.transform;	// make the object move with this platform by making this its parent 
	}

	// When an object leaves the platform, stop it from moving with the platform
	void OnTriggerExit2D(Collider2D collider)
	{
		collider.transform.parent = null;	// stop making it move with this platform
	}

}
