/*
 * PlayerInputController.cs
 * modified by Peter Hunt (from Platformer2DUserController script in the UnityStandardAssets._2D package)
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
		bool crouch = Input.GetKey(KeyCode.LeftShift);

		/**
		if (shoot) { shoot = false; }
		else if (firePressed && !shoot) { shoot = true; }
		else { shoot = false; }
**/

		//bool shoot = Input.GetKey(KeyCode.Space);
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		if (CrossPlatformInputManager.GetButton("Jump") && CrossPlatformInputManager.GetButton("Fire1"))
		{
			Debug.Log("FIRE UP !!");
		} 
		else if (v < 0f && CrossPlatformInputManager.GetButton("Fire1"))
		{
			Debug.Log("FIRE DOWN - TURBO JUMP !!");

		}
    	// Pass all parameters to the character control script.
    	playerController.Move(h, crouch, jumpPressed, firePressed);
    	jumpPressed = false;
		firePressed = false;
    }

}
