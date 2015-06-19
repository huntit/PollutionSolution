/* 
 * Parallax.cs
 * By Max Finn
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	public Transform cameraTrans, topLeft, bottomRight, worldAdjust;
	private float xGradient, xIntercept, yGradient, yIntercept;

	// Use this for initialization
	private void Start()
	{
		xGradient = ((bottomRight.position.x - 14f) - (topLeft.position.x + 14f))/(bottomRight.position.x - topLeft.position.x);
	
		xIntercept = (topLeft.position.x + 14f) - (xGradient * topLeft.position.x) + worldAdjust.position.x;

		yGradient = ((bottomRight.position.y + 14.7f) - (topLeft.position.y - 13.3f))/(bottomRight.position.y - topLeft.position.y);

		yIntercept = (topLeft.position.y + 14.7f) - (xGradient * topLeft.position.y) + worldAdjust.position.y;
	}
	
	// Update is called once per frame
	private void Update()
	{
		transform.position = new Vector3(xGradient * cameraTrans.position.x + xIntercept, yGradient * cameraTrans.position.y + yIntercept, 6f);
	}
}
