/* 
 * AirBar Script by Laura Yarnold
 * 
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirBar : MonoBehaviour 

	// Creates public access for a healthbar, and sets the Avatar contoller to be avatar
{
	public HealthBar healthBar;
	public AvatarController avatar;

	// Creates a range between 1 - 20 of health loss per second
	[Range(1, 20)] public float healthLossPerSec = 7f;

	// Creates a range between 1 - 20 for how quickly the avatar drowns 
	[Range(1, 20)] public float drownRate = 5f;

	// Creates a range between 1 - 10 of how quicky the air bar fills when on land
	[Range(0, 10)] public float breatheRate = 2f;

	// Creates public access for a airbar (under Unity UI elements), and sets air to full (= 100%)
	private Slider airSlider;
	private float air = 100f;

	// Gets the value of air, and sets the air to be a value between 0 and 100
	public float Air	
	{
		get { return air; }

		set
		{
			// Keep the air to be between 0 and 100
			air = Mathf.Clamp(value, 0f, 100f);
			// Sets the UI airSlider to equal the amount of air.
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

		// Consume air while under water
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


