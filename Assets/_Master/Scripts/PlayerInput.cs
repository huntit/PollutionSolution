/*
 * PlayerInputController.cs
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
	private AvatarController avatarController;	// reference to the PlayerController to pass Move() instructions to
    private bool jumpPressed;
	private bool firePressed;
	private bool superJumpPressed;

	private void Awake()
    {
    	avatarController = GetComponent<AvatarController>();
    }

	private void Update()
    {
		// Read the jump and fire input buttons in Update so button presses aren't missed.
		if (!jumpPressed) { jumpPressed = CrossPlatformInputManager.GetButtonDown("Jump"); }
		if (!firePressed) { firePressed = CrossPlatformInputManager.GetButtonDown("Fire1"); }
	}

    private void FixedUpdate()
    {
    	// Read the inputs.
    	float moveH = CrossPlatformInputManager.GetAxis("Horizontal");
		float moveV = CrossPlatformInputManager.GetAxis("Vertical");
		//bool crouch = Input.GetKey(KeyCode.LeftShift);

		if (firePressed && CrossPlatformInputManager.GetButton("Jump"))
		{
			Debug.Log("FIRE UP !!");
		} 
		else if (firePressed && moveV < 0f)
		{
			Debug.Log("FIRE DOWN - SUPER JUMP !!");
			superJumpPressed = true;
		}

    	// Pass all parameters to the character control script.
		avatarController.Move(moveH, moveV, jumpPressed, superJumpPressed, firePressed);
    	jumpPressed = false;
		firePressed = false;
		superJumpPressed = false;
    }

}
