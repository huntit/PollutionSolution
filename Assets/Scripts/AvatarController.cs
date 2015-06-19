/*
 * AvatarController.cs
 * by Peter Hunt 

 * This script controls avatar movement and abilities including left, right, jump (if grounded), double-jump (if air-borne) and shoot
 * If underswater, it includes swim and dash
 * Exposes public method Move() for calling from the PlayerInputController script
 * (Some ideas sourced from the PlatformerCharacter2D script in the UnityStandardAssets._2D package)
 * 
 */

using System;
using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour
{
	// variables to be tweaked in the editor
	public float airPerProjectile = 5f;				// Air used per airgun shot
	public float airPerDoubleJump = 20f;			// Air used per double-jump
	public float airPerUnderwaterDash = 5f;			// Air used per underwater dash
	public float projectileForce = 10f;				// Force applied to the projectile when it is shot
	public float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	public float jumpForce = 400f;                  // Amount of force added when the player jumps.
	public float doubleJumpForce = 200f;            // Amount of force added when the player double-jumps.
	public float swimForce = 20f;                   // Amount of force added when the player swims.
	public float swimTurnSpeed = 2f;                // Speed the avatar can turn underwater
	public float underwaterDashForce = 550f;        // Amount of force added when the player does an underwater dash
	public bool airControl = true;                  // Whether or not a player can steer while jumping;
	public LayerMask whatIsGround;                  // A mask determining what is ground to the character

	// sound effects
	public AudioClip jumpSound;						// sound to play when jumping
	public AudioClip doubleJumpSound;				// sound to play when double-jumping
	public AudioClip leftFootSound;					// sound to play when walking
	public AudioClip rightFootSound;				// sound to play when walking
	public AudioClip damageSound;					// sound to play when hit
	public AudioClip swimSound;						// sound to play when swimming
	public AudioClip dieSound;						// sound to play when dying
	public AudioClip buzzerSound;					// sound to play when can't shoot, double-jump or dash

	// references to other game objects
	public PoisonIcon poisonIcon;					// reference to the UI poison icon
	public AirBar airBar;							// reference to the UI air bar
	public LevelPollution levelPollution;			// reference to the Level Pollution counter script
	public GameObject projectile;					// Projectile prefab that the player shoots
	public bool inWater;							// whether the avatar is in the water

	private bool grounded;            				// whether or not the player is grounded
	private bool facingRight = true;  				// for determining which way the player is currently facing in the x axis
	private bool facingUp;  						// for determining which  way the player is currently facing in the y axis when swimming
	private bool invulnerable;						// whether the avatar is currently invulnerable.
	private bool doubleJumpAllowed = true;			// whether double-jump is allowed (ie. not currently double-jumping)
    private Transform groundCheck;    				// A position marking where to check if the player is grounded.
	private Transform shootingPosition;    		    // A position marking where to shoot projectiles from.
	private Animator anim;            				// Reference to the avatar's animator component.
    private Rigidbody2D rb;							// Reference to the avatar's Rigidbody2D component

	const float GROUNDED_RADIUS = .2f; 				// Radius of the overlap circle to determine if grounded


	// Setup references used throughout the class
	private void Awake()
	{
         groundCheck = transform.Find("GroundCheck");
		 shootingPosition = transform.Find("ShootingPosition");
         anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
	}


	// Check if the avatar is grounded
	// Set avatar animation parameters - for swim, grounded, vSpeed and inWater - so correct animation is playing
	private void FixedUpdate()
	{
		if (!inWater)	// If not underwater, check if the player is grounded, and set animation appropriately
		{
	    	grounded = false;
	        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
	        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, GROUNDED_RADIUS, whatIsGround);
			foreach (Collider2D collider in colliders)
			{
				if (collider.gameObject != gameObject) 
				{ 
					grounded = true;
					doubleJumpAllowed = true;	// on the ground, so allow double-jump again
				}
			}

			// Set animation parameters
			anim.SetBool("Swim", false);
	        anim.SetBool("Ground", grounded);
	        anim.SetFloat("vSpeed", rb.velocity.y);   
		}

		anim.SetBool("inWater", inWater);	// activate / deactivate the idle swim animation
	}


	// Check if the avatar has entered the water or waterwaves
	// On entering the water, set inWater variable to true, allow the avatar sprite to rotate, and reduce the gravity scale
	// On entering waterwaves from outside the water, play a splash sound, show a splash particle effect and push the avatar down into the water
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Water")) 
		{ 
			inWater = true;
			rb.fixedAngle = false;		// allow the avatar to rotate underwater
			rb.gravityScale = 0.5f;		// reduce gravity underwater
		}
		else if (other.CompareTag("WaterWaves") && !inWater)
		{
			// play a splash sound
			AudioSource audioSource = other.GetComponent("AudioSource") as AudioSource;
			if (audioSource) { audioSource.Play(); }

			// Instantitate the AirgunExplosion prefab particle effect to act as a 'splash'
			Instantiate (Resources.Load("AirgunExplosion"), transform.position, transform.rotation);	

			// Apply a downward force to push the avatar into the water
			rb.AddForce(new Vector2(0, -jumpForce /2f)); 	
		}
	}


	// Check if the avatar has exited the water
	// On exiting water, set inWater to false, snap the avatar back to upright and disable rotation, modify gravity scale back to normal and pop the avatar out of the water
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Water")) 
		{ 
			inWater = false; 
			transform.rotation = Quaternion.Euler(Vector3.zero); // snap back to upright
			rb.fixedAngle = true;	// disable sprite rotation
			rb.gravityScale = 2;	// put gravity back to normal

			// Apply a vertical force to pop the avatar out of the water
			rb.AddForce(new Vector2(0f, jumpForce)); 		
			PlaySoundEffect(jumpSound, 0.5f);
		}
	}


	// Check if the avatar has collided with an enemy
	// If so, apply a force to push them backwards, poison the avatar and enable invulnerability for a few seconds
	void OnCollisionEnter2D(Collision2D collision)
	{
		// if avatar collides with enemy, and is not invulnerable, poison avatar, and set temporarily invulnerable
		if (!invulnerable && collision.gameObject.CompareTag("Enemy"))
		{
			PlaySoundEffect(damageSound, 0.8f);

			// push the player backwards
			rb.AddForce(-Vector2.right * transform.localScale.x * 1000f * rb.gravityScale);

			// enable temporary invulnerability and poison avatar
			StartCoroutine(EnableInvulnerability());
			poisonIcon.Poisoned = true;
		}
	}


	/* 
	 * Main avatar movement method 
	 * Called from the FixedUpdate() method in PlayerInput Controller
	 * Calls Swim() if the avatar is in the water, otherwise moves the avatar left/right, jump, double-jump and shoot
	 * Only allows jump if the avatar is grounded, and double-jump if the avatar is in the air and not currently double-jumping
	 * Flips the player sprite if they change direction
	 */
	public void Move(float moveH, float moveV, bool jump, bool shoot)
	{
		// Swim if in the water
		if (inWater)
		{
			Swim (moveH, moveV, shoot);		
			return;
		}
		
		// Move left/right
		if (grounded || airControl) 	// only allow left/right control if grounded or airControl is turned on
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(moveH));

            // Move the character in the x axis
            rb.velocity = new Vector2(moveH * maxSpeed, rb.velocity.y);

            // If changing direction, flip the player left/right
			if ((moveH > 0 && !facingRight) || (moveH < 0 && facingRight))
            {
             	Flip();
            }
		}
		
        // Jump
        if (grounded && jump && anim.GetBool("Ground"))
		{
            grounded = false;
            anim.SetBool("Ground", false);

			// Add a vertical force to the player
			rb.AddForce(new Vector2(0f, jumpForce));
			PlaySoundEffect(jumpSound, 0.8f);

			// "Daring Fireball" fire jump special effect
			// Instantiate the FireJump prefab particle effect
			GameObject daringFireball = (Instantiate (Resources.Load("FireJump"), groundCheck.position, transform.rotation)) as GameObject;
			daringFireball.tag = "Avatar Fireball";
			daringFireball.layer = LayerMask.NameToLayer("Ground");
			levelPollution.levelTime -= 1;		// add some pollution to the level for using the fire jump (reduce available time)
        }
		// Double-jump
		else if (jump && CanDoubleJump()) 		
		{
			PlaySoundEffect(doubleJumpSound, 1f);

			// Instantitate the AirgunExplosion prefab particle effect
			Instantiate (Resources.Load("AirgunExplosion"), shootingPosition.position, transform.rotation);	

			airBar.Air -= airPerDoubleJump;	// reduce air for double-jump

			// Add an additional vertical force to the player
			rb.AddForce(new Vector2(0f, jumpForce));
			doubleJumpAllowed = false;	// already double-jumped, not allowed again until on the ground (to prevent triple-jump, etc)
		}

		// Shoot
		if (shoot && CanShootAirGun())
		{
			// if not already shooting, run the shoot animation
			if (!anim.GetBool("Shoot")) 
			{
			   anim.SetBool("Shoot", true);	// Run the shoot animation (and fires the projectile at the correct keyframe)
			}
			shoot = false;
		}
		else
		{
			anim.SetBool("Shoot", false);
		}	
	}


	// When underwater, rotate the avatar using the horizontal axis, move the avatar forward using the vertical axis
	// Pressing 'shoot' applies a forward force for an underwater 'dash'
	private void Swim(float moveH, float moveV, bool shoot)
	{
		transform.Rotate(Vector3.back * moveH * swimTurnSpeed);	// horizontal axis - rotate the avatar
		
		// vertical axis (up) - move the avatar forward
		if (moveV > 0)
		{
			// Instantiate the BubbleUnderwater prefab particle effect
			Instantiate (Resources.Load("BubblesUnderwater"), groundCheck.position, transform.rotation);	
			
			rb.AddForce(transform.up * moveV * swimForce);
		} 
		
		anim.SetBool("Swim", (moveV > 0));	// activate/de-activate the swim animation based on whether the player is swimming forward
		
		// if shoot is pressed underwater, do an underwater dash and use up some air
		if (shoot && CanUnderwaterDash())
		{
			PlaySoundEffect(doubleJumpSound, 1f);
			
			// Instantitate the AirgunExplosion prefab particle effect
			Instantiate (Resources.Load("AirgunExplosion"), shootingPosition.position, transform.rotation);	
			
			airBar.Air -= airPerUnderwaterDash;	// reduce air for underwater dash
			
			// Add an additional forward force to the avatar
			rb.AddForce(transform.up * moveV * underwaterDashForce);
		}
	}


	/** Utility Methods called by Move(), Swim() and animation events **/

	// Flip the avatar horizontally
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}


	// Check if there is enough air available to shoot the air gun
	// If not, play buzzerSound
	private bool CanShootAirGun()
	{
		if (airBar.Air >= airPerProjectile)
		{
			return true;
		}
		else
		{
			PlaySoundEffect(buzzerSound, 0.8f);
			return false;
		}
	}


	// Check if double-jump is allowed (ie. not currently double-jumping), there is enough air available to double-jump, and the avatar is not grounded
	// If not, play buzzerSound
	private bool CanDoubleJump()
	{
		if (doubleJumpAllowed && airBar.Air >= airPerDoubleJump && !grounded && !anim.GetBool("Ground"))
		{
			return true;
		}
		else
		{
			PlaySoundEffect(buzzerSound, 0.8f);
			return false;
		}
	}


	// Check if in the water, and there is enough air available to do an underwater dash
	// If not, play buzzerSound
	private bool CanUnderwaterDash()
	{
		if (inWater && airBar.Air >= airPerUnderwaterDash)
		{
			return true;
		}
		else
		{
			PlaySoundEffect(buzzerSound, 0.8f);
			return false;
		}
	}


	// Instantiate a new projectile, fire it and reduce available air
	// Called from the PlayerShoot animation at the correct keyframe
	public void FireProjectile()
	{
		// Play projectile firing sound
		PlaySoundEffect(projectile.GetComponent<Projectile>().firingSound, 0.8f);

		// Instantiate a projectile prefab and tag it
		GameObject clone = Instantiate(projectile, shootingPosition.position, transform.rotation) as GameObject;
		clone.transform.localScale = transform.localScale; // flip the projectile if the character is facing left
		clone.tag = "Avatar Projectile";

		// Apply force to fire the projectile
		clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * projectileForce, 0f), ForceMode2D.Impulse);

		// Instantitate the AirgunExplosion prefab particle effect
		Instantiate (Resources.Load("AirgunExplosion"), shootingPosition.position, transform.rotation);		

		// reduce air
		airBar.Air -= airPerProjectile;	
	}

	
	// Enables invulnerability for approx 3 seconds, changes alpha and flashes sprite as invulnerability ends
	private IEnumerator EnableInvulnerability()
	{
		invulnerable = true;
		// flash the sprite
		Color originalColor = new Color(1f, 1f, 1f, 1f);
		Color newColor = new Color(1f, 0f, 0f, 1f);
		for (int i = 0; i <= 12; i++)
		{
			gameObject.GetComponent<SpriteRenderer>().color = (i % 2 == 0) ? newColor : originalColor;
			yield return new WaitForSeconds((i > 5) ? 0.15f : 0.4f);
		}
		gameObject.GetComponent<SpriteRenderer>().color = originalColor;
		
		invulnerable = false;
	}
	
	
	// Utility method to play a sound effect at the player location, with the specified volume
	private void PlaySoundEffect(AudioClip soundEffect, float volume)
	{
		if (soundEffect) { AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume); }
	}


	// Called from PlayerWalk animation at the correct frame
	public void PlayLeftFootSound() 
	{
		PlaySoundEffect(leftFootSound, 0.3f);
	}


	// Called from PlayerWalk animation at the correct frame
	public void PlayRightFootSound() 
	{
		PlaySoundEffect(rightFootSound, 0.3f);
	}


	// Called from PlayerSwim animation at the correct frame
	public void PlaySwimSound() 
	{
		PlaySoundEffect(swimSound, 1.0f);
	}


	// Called from GameManager when avatar dies
	public void Die()
	{
		PlaySoundEffect(dieSound, 1.0f);
	}

}
