/* 
 * AirBar Script by Laura Yarnold
 * 
 * Creates an air bar UI element (displayed on GUI) that is affected by drowning, jumping and air gun use. Air regenerates when on land. 
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirBar : MonoBehaviour 
{
	// Create public access for a healthbar
	public HealthBar healthBar;

	// Set the Avatar contoller to be avatar
	public AvatarController avatar;

	// Create a public range between 1 - 20 of health loss per second
	[Range(1, 20)] public float healthLossPerSec = 7f;

	// Create a public range between 1 - 20 for how quickly the avatar drowns 
	[Range(1, 20)] public float drownRate = 5f;

	// Create a public range between 1 - 10 of how quicky the air bar fills when on land
	[Range(0, 10)] public float breatheRate = 2f;

	// Create public access for a airbar (under Unity UI elements)
	private Slider airSlider;

	//Set air value to full (= 100%) on the AirBar Slider
	private float air = 100f;

	// Get the value of air, and sets the air to be a value between 0 and 100

	public float Air	
	{
		// Returns the value of air
		get { return air; }

		set
		{
			// Keep the air to be between 0 and 100
			air = Mathf.Clamp(value, 0f, 100f);

			// Set the UI airSlider to equal the amount of air
			airSlider.value = Air;
		}
	}

	// Gets the UI component Slider
	void Start()
	{
		airSlider = GetComponent<Slider>();
	}

	void FixedUpdate()
	{

		// Consume air while under water over time
		if (avatar.inWater)
		{
			Air -= drownRate * Time.fixedDeltaTime;

			// If you run out of air, and are in the water, lose health
			if (air <= 0f)
			{
				healthBar.Health -= healthLossPerSec * Time.fixedDeltaTime; 
			}

		}

		else // Out of the water, slowly regenerate air
		{ 
			Air += breatheRate * Time.fixedDeltaTime;
		}
	}
}


