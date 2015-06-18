/*
 * PlayerInput.cs
 * by Peter Hunt (some code modified from Platformer2DUserController script in the UnityStandardAssets._2D package)
 * 
 * Handles player input in a cross platform manner, for controlling a 2D character, with left, right, shoot, jump and super-jump
 * 
 */
 
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
	private AvatarController avatarController;	// reference to the AvatarController to pass Move() instructions to
    private bool jumpPressed;
	private bool firePressed;

	// Setup references used in the class
	private void Awake()
    {
    	avatarController = GetComponent<AvatarController>();
    }

	// Read the jump and fire input buttons in Update, so button presses aren't missed.
	private void Update()
    {
		if (!jumpPressed) { jumpPressed = CrossPlatformInputManager.GetButtonDown("Jump"); }
		if (!firePressed) { firePressed = CrossPlatformInputManager.GetButtonDown("Fire1"); }
	}

	// Read the horizontal and vertical axis inputs
	// Call the Move() method on the avatarController, passing the axis inputs, jumpPressed and firePressed statuses
    private void FixedUpdate()
    {
    	float moveH = CrossPlatformInputManager.GetAxis("Horizontal");
		float moveV = CrossPlatformInputManager.GetAxis("Vertical");

    	// Pass all input parameters to the avatar control script
		avatarController.Move(moveH, moveV, jumpPressed, firePressed);
    	jumpPressed = false;
		firePressed = false;
    }

}
