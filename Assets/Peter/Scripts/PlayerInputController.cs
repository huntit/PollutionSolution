/*
 * PlayerInputController.cs
 * by Peter Hunt (some code modified from Platformer2DUserController script in the UnityStandardAssets._2D package)
 * 
 * Handles player input in a cross platform manner, for controlling a 2D character, with left, right and jump
 * 
 */
 
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//namespace UnityStandardAssets._2D
//{
//    [RequireComponent(typeof (PlatformerCharacter2D))]


public class PlayerInputController : MonoBehaviour
{
	private PlayerController playerController;	// reference to the PlayerController to pass Move() instructions to
    private bool jumpPressed;
	private bool firePressed;
	private bool superJumpPressed;

	private void Awake()
    {
    	playerController = GetComponent<PlayerController>();
    }

	private void Update()
    {
		// Read the jump input in Update so button presses aren't missed.

		if (!jumpPressed) { jumpPressed = CrossPlatformInputManager.GetButtonDown("Jump"); }

		if (!firePressed) { firePressed = CrossPlatformInputManager.GetButtonDown("Fire1"); }

	}

    private void FixedUpdate()
    {
    	// Read the inputs.
    	float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		bool crouch = Input.GetKey(KeyCode.LeftShift);

		if (firePressed && CrossPlatformInputManager.GetButton("Jump"))
		{
			Debug.Log("FIRE UP !!");
		} 
		else
		if (firePressed && v < 0f)
		{
			Debug.Log("FIRE DOWN - SUPER JUMP !!");
			superJumpPressed = true;
		}
    	// Pass all parameters to the character control script.
    	playerController.Move(h, crouch, jumpPressed, firePressed, superJumpPressed);
    	jumpPressed = false;
		firePressed = false;
		superJumpPressed = false;
    }

}
