/*
 * PlayerController.cs
 * by Peter Hunt (uses ideas from PlatformerCharacter2D script in the UnityStandardAssets._2D package)
 * 
 * Script to control player movement, including left, right, jump (if grounded), and crouch
 * Exposes public method Move(float move, bool crouch, bool jump) for calling from the PlayerInputController script
 * 
 */
using System;
using UnityEngine;

//namespace UnityStandardAssets._2D
//{

public class PlayerController : MonoBehaviour
{
	//public float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    //public float jumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] public float crouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    public bool airControl = false;                 // Whether or not a player can steer while jumping;
    public LayerMask whatIsGround;                  // A mask determining what is ground to the character
	public GameObject projectile;					// Projectile prefab that the player shoots
	public float projectileForce = 5.0f;			// Force applied to the projectile when it is shot

    private Transform groundCheck;    				// A position marking where to check if the player is grounded.
    const float GROUNDED_RADIUS = .2f; 				// Radius of the overlap circle to determine if grounded
    private bool grounded;            				// Whether or not the player is grounded.
    private Transform ceilingCheck;   				// A position marking where to check for ceilings
    const float CEILING_RADIUS = .01f; 				// Radius of the overlap circle to determine if the player can stand up
    private Animator anim;            				// Reference to the player's animator component.
    private Rigidbody2D rb;							// Reference to the Rigidbody2D component
    private bool facingRight = true;  				// For determining which way the player is currently facing.
	private Transform shootingPosition;    		    // A position marking where to shoot projectiles from.
	private PlayerStats playerStats;				// Reference to the Player Statistics object for this player

	private void Awake()
	{
		// set references
         groundCheck = transform.Find("GroundCheck");
         ceilingCheck = transform.Find("CeilingCheck");
		 shootingPosition = transform.Find("ShootingPosition");

         anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
		 playerStats = GetComponent<PlayerStats>();
	}

	private void FixedUpdate()
	{
		// Check is the player is grounded
    	grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, GROUNDED_RADIUS, whatIsGround);

		foreach (Collider2D collider in colliders)
		{
			if (collider.gameObject != gameObject) { grounded = true; }
		}

        anim.SetBool("Ground", grounded);

        // Set the vertical animation
        anim.SetFloat("vSpeed", rb.velocity.y);   
	}

	// Called from PlayerInput Controller
	// Moves the player left/right, jump, crouch
	// Only allows jump if the player is grounded
	// Flips the player sprite if they change direction
	public void Move(float move, bool crouch, bool jump, bool shoot, bool superJump)
	{
		// CROUCH ...
		// If crouching, check to see if the character can stand up
        if (!crouch && anim.GetBool("Crouch"))
		{
        	// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(ceilingCheck.position, CEILING_RADIUS, whatIsGround)) { crouch = true; }
        }
        // Set whether or not the character is crouching in the animator
        anim.SetBool("Crouch", crouch);


		// MOVE LEFT/RIGHT ...
		if (grounded || airControl) 	// only control the player if grounded or airControl is turned on
        {
        	// Reduce the speed if crouching by the crouchSpeed multiplier
        	move = (crouch ? move * crouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character in the x axis
            rb.velocity = new Vector2(move * playerStats.MaxSpeed, rb.velocity.y);

            // If changing direction, flip the player left/right
			if ((move > 0 && !facingRight) || (move < 0 && facingRight))
            {
             	Flip();
            }
		}


        // JUMP ...
        if (grounded && jump && anim.GetBool("Ground"))
		{
            grounded = false;
            anim.SetBool("Ground", false);

			// Add a vertical force to the player
			rb.AddForce(new Vector2(0f, playerStats.JumpForce));
        }


		// SUPERJUMP ...
		if (grounded && superJump && playerStats.CanShootProjectile() && anim.GetBool("Ground"))
		{
			grounded = false;
			anim.SetBool("Ground", false);
			
			// Add a vertical force to the player
			rb.AddForce(new Vector2(0f, playerStats.SuperJumpForce));
			playerStats.ReduceAirForProjectileShot();	
		}

		
		/**
		// SHOOT UP ...
		if (jump && shoot)
		{
			Debug.Log("Fire UP !!");
		}
**/

		// SHOOT ...
		if (shoot)
		{
			// if not already shooting, run the animation
			if (!anim.GetBool("Shoot")) 
			{
			   Debug.Log("Fire !!");
			   anim.SetBool("Shoot", true);	// Run the shoot animation (and fires the projectile at the correct keyframe)
			   //fireProjectile();
			}
			shoot = false;
		}
		else
		{
			anim.SetBool("Shoot", false);
		}


	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}

	// instantiate a new projectile and fire it
	// called from the animation at the correct keyframe
	public void FireProjectile()
	{
		if (playerStats.CanShootProjectile())
		{
			this.PlayProjectileSound();
			playerStats.ReduceAirForProjectileShot();
			GameObject clone = Instantiate(projectile, shootingPosition.position, transform.rotation) as GameObject;
			clone.transform.localScale = transform.localScale; // flip the projectile if the character is facing left
			clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * projectileForce, 0f), ForceMode2D.Impulse);

		}
	}

	private void PlayProjectileSound() 
	{
		// get the firingSound property audio clip for the attached Projectile script, and play it
		if (projectile.GetComponent<Projectile>().firingSound) 
		{ 
			AudioSource.PlayClipAtPoint(projectile.GetComponent<Projectile>().firingSound, transform.position);
		}

	}

	/**
	void PlayLeftFootSound () {
		if (leftFootSound) {
			AudioSource.PlayClipAtPoint(leftFootSound, transform.position);
		}
	}
	
	void PlayRightFootSound () {
		if (rightFootSound) {
			AudioSource.PlayClipAtPoint(rightFootSound, transform.position);
		}
	}
	
	void PlayJetpackSound() {
		if (!jetpackSound || GameObject.Find("RocketSound"))
			return;
		
		GameObject go = new GameObject("RocketSound");
		AudioSource aSrc = go.AddComponent<AudioSource>();
		aSrc.clip = jetpackSound;
		aSrc.volume = 0.7f;
		aSrc.Play ();	
		
		Destroy(go,jetpackSound.length);
	}
**/



}
