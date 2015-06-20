/* 
 * Platform.cs
 * By Max Finn
 * 
 * These platforms move back and forth between two Transforms as defined in the scene at a given speed.
 * They also keep anything that is on top of them moving with them, until the object moves/is moved off.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
	public float speed = 4f;
	private float startTime; // The time at which a platform begins a trip from pointA to pointB or vice versa
	private float journeyLength;
	private bool travelForwards = false;
	public Transform pointA, pointB;

	// Use this for initialization
	private void Start()
	{
		transform.position = pointA.position; // Make sure the platform is in the correct starting position
		startTime = Time.time;
		journeyLength = Vector3.Distance(pointA.position, pointB.position);
	}

	private void FixedUpdate()
	{
		float distCovered = (Time.time - startTime) * speed; // Converts to the percentage of trip from A to B covered in next line
		// If travelling forwards, a greater distCovered will make fracJourney bigger, and the opposite is true if not travelling forwards
		float fracJourney = (travelForwards) ? distCovered / journeyLength : (journeyLength - distCovered) / journeyLength;

		transform.position = Vector3.Lerp (pointA.position, pointB.position, fracJourney);
		// If the percentage of trip covered leaves the range of 0% to 100%, reverse platform direction and reset startTime
		if (fracJourney <= 0 || fracJourney >= 1) // Tests true once at start of game; travelForwards will be true for first journey
		{
			travelForwards = !travelForwards;
			startTime = Time.time;
		}
	}

	/*Added by Peter start*/
	// If an object collides with the trigger at the top of the platform, make it move with the platform
	private void OnTriggerEnter2D(Collider2D other)
	{
		other.transform.parent = transform;	// make the object move with this platform by making this its parent 
	}

	// When an object leaves the platform, stop it from moving with the platform
	private void OnTriggerExit2D(Collider2D other)
	{
		other.transform.parent = null;	// stop making it move with this platform
	}
	/*Added by Peter end*/
}
