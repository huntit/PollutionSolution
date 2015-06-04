/*
 * CameraFollow2D.cs
 * modified by Peter Hunt (from Camera2DFollow script in the UnityStandardAssets._2D package)
 * 
 * Script to have the camera follow the main player, with damping and look ahead control
 */

using System;
using UnityEngine;

//namespace UnityStandardAssets._2D
//{
public class CameraFollow2D : MonoBehaviour
{
	public Transform target;
    public float damping = 1;						// larger damping = smoother camera movement
    public float lookAheadFactor = 3;				// distance to look ahead with the camera. larger = longer distance
    public float lookAheadReturnSpeed = 0.5f;		// speed the camera springs back after look ahead
    public float lookAheadMoveThreshold = 0.1f;		// amount the player has to move before the look ahead function kicks in

    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
	private Vector3 lookAheadPos;

    private void Start()
    {
    	lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }

	private void Update()
    {
    	// only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - lastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
        	lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
        	lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        transform.position = newPos;
        lastTargetPosition = target.position;
	}

}

