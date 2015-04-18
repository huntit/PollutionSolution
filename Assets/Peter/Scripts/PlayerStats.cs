/*
 * PlayerStats.cs
 * by Peter Hunt
 * 
 * Script to store, update and calculate player statistics.
*
 * Public read-write properties for a character are Air, Health, Poisoned, Agility, Discipline, and Strength
 * Public read-only properties for a character are MaxSpeed, JumpForce
 * 
 * When Agility, Discipline or Strength are set ...
 * Agility modifies the maximum player speed and the jump force
 * Discipline modifies the amount of air consumed underwater and for each projectile shot
 * Strength modifies the projectile force and amount of health lost when hit or poisoned
 */

using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
	// Starting values available in the inspector
	public float baselineMaxSpeed = 10f;					// baseline maximum speed, without adjusting for agility
	public float baselineJumpForce = 600f;					// baseline jump force, without adjusting for agility
	public float baselineSuperJumpForce = 800f;				// baseline superjump force, without adjusting for agility
	public float baselineAirPerProjectile = 20f;			// baseline amount of air used per projectile shot
	public float baselineAirPerSecondUnderwater = 2.0f;		// baseline amount of air consumed per second under water
	public float baselineHealthLostPerHit = 10.0f;			// baseline amount of health lost per hit

	// Private member variables
	// Allow the starting values to be modified in the inspector
	[SerializeField] [Range(1, 199)] private int agility;
	[SerializeField] [Range(1, 199)] private int discipline;
	[SerializeField] [Range(1, 199)] private int strength;
	[SerializeField] [Range(0, 100)] private float air = 100.0f;
	[SerializeField] [Range(0, 100)] private float health = 100.0f; 

	private float maxSpeed;
	private float jumpForce;
	private float superJumpForce;
	private float airPerProjectile;
	private float airPerSecondUnderwater;
	private float healthLostPerHit;

	// Public properties
	public bool Poisoned { get; set; }
	public float MaxSpeed { get { return maxSpeed; } }		// Read Only property - the fastest the player can travel in the x axis
	public float JumpForce { get { return jumpForce; } }	// Read Only property - the amount of force added when the player jumps
	public float SuperJumpForce { get { return superJumpForce; } }	// Read Only property - the amount of force added when the player superjumps

	public float Air
	{
		get { return air; }
		set { air = Mathf.Clamp(value, 0f, 100f); }
	}

	public float Health
	{
		get { return health; }
		set { health = Mathf.Clamp(value, 0f, 100f); }
	}

	// <100 = less than baseline, 100 = baseline, >100 = greater than baseline
	public int Agility	
	{
		get { return agility; }

		set
		{
			agility = Mathf.Clamp (value, 1, 199);

			// Adjust maxSpeed depending on the player's new Agility value
			float agilitySpeedAdjustment = agility / 100f;
			maxSpeed = baselineMaxSpeed * agilitySpeedAdjustment;

			// Adjust jumpForce depending on the player's new Agility value
			float agilityJumpAdjustment = agility / 100f;
			jumpForce = baselineJumpForce * agilityJumpAdjustment;

			// Adjust superJumpForce depending on the player's new Agility value
			float agilitySuperJumpAdjustment = agility / 100f;
			superJumpForce = baselineSuperJumpForce * agilitySuperJumpAdjustment;

		}
	}


	public int Discipline
	{
		get { return discipline; }
		
		set
		{
			discipline = Mathf.Clamp (value, 1, 199);;

			// Adjust airPerProjectile depending on the player's new Discipline value
			// Higher Discipline = Less Air Spent per projectile
			float disciplineAirPerProjectileAdjustment = 100f / discipline;
			airPerProjectile = baselineAirPerProjectile * disciplineAirPerProjectileAdjustment;
		
		}
	}

	public int Strength
	{
		get { return strength; }
		
		set
		{
			strength = Mathf.Clamp (value, 1, 199);

			// Adjust healthLostPerHit depending on the player's new Strength value
			float strengthHealthLostPerHitAdjustment = 1.0f;
			healthLostPerHit = baselineHealthLostPerHit * strengthHealthLostPerHitAdjustment;
		}
	}
	

	// Use this for initialization
	void Start () {

		// Set the public preperty values as per the values set in the inspector, which will set all the calculated properties
		Agility = agility;
		Discipline = discipline;
		Strength = strength;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Air <= 0)
		{ 
			Debug.Log("You are out of air");
		}
		
		if (Poisoned)
		{
			Debug.Log("You are poisoned");
		}

		if (Health <= 0)
		{
			Debug.Log("You are dead");
		}
	}


	// Return true if there's enough air let to fire a projectile
	public bool CanShootProjectile()
	{
		return (Air >= airPerProjectile);
	}

	// Shot a projectile, so reduce the amount of air in the supply
	public void ReduceAirForProjectileShot()
	{
		Air -= airPerProjectile;
	}

	// Player has been hit, so reduce health
	public void ReduceHealthForHit()
	{
		Health -= healthLostPerHit;
	}

}
