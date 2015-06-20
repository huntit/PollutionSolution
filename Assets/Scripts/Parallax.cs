/* 
 * Parallax.cs
 * By Max Finn
 * 
 * This script takes the furthest points (top left and bottom right) the player will be during a level,
 * and maps the background sprite to them so that slowly shifts behind the player as they move about the level.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	// cameraTrans is the camera's location, worldAdjust is the top level empty gameObject which holds all the level's terrain
	public Transform cameraTrans, topLeft, bottomRight, worldAdjust;
	private float xGradient, xIntercept, yGradient, yIntercept;

	// Use this for initialization
	private void Start()
	{
		// Mapping the distance between the player's leftmost and rightmost points to that of the background
		xGradient = ((bottomRight.position.x - 14f) - (topLeft.position.x + 14f))/(bottomRight.position.x - topLeft.position.x);
	
		// Adjusts the mapping's x values from being by the world's origin
		xIntercept = (topLeft.position.x + 14f) - (xGradient * topLeft.position.x) + worldAdjust.position.x;

		// Mapping the distance between the player's highest and lowest points to that of the background
		yGradient = ((bottomRight.position.y + 14.7f) - (topLeft.position.y - 13.3f))/(bottomRight.position.y - topLeft.position.y);

		// Adjusts the mapping's y values from being by the world's origin
		yIntercept = (topLeft.position.y + 14.7f) - (xGradient * topLeft.position.y) + worldAdjust.position.y;
	}
	
	// Update is called once per frame
	private void Update()
	{
		// Applying the mapping, a depth of 6f keeps the background behind the rest of the sprites
		transform.position = new Vector3(xGradient * cameraTrans.position.x + xIntercept, yGradient * cameraTrans.position.y + yIntercept, 6f);
	}
}
