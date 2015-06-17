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
{
	public HealthBar healthBar;
	public AvatarController avatar;

	[Range(1, 20)] public float healthLossPerSec = 7f;
	[Range(1, 20)] public float drownRate = 5f;
	[Range(0, 10)] public float breatheRate = 2f;

	private Slider airSlider;
	private float air = 100f;

	public float Air	
	{
		get { return air; }

		set
		{
			// keep the air to be between 0 and 100
			air = Mathf.Clamp(value, 0f, 100f);
			airSlider.value = Air;
		}
	}

	void Start()
	{
		airSlider = GetComponent<Slider>();
	}

	void FixedUpdate()
	{

		// consume air while under water
		if (avatar.inWater)
		{
			Air -= drownRate * Time.fixedDeltaTime;

			// If you run out of air, and are in the water, lose health
			if (air <= 0f)
			{
				healthBar.Health -= healthLossPerSec * Time.fixedDeltaTime; 
			}

		}
		else // out of the water, slowly regenerate air
		{ 
			Air += breatheRate * Time.fixedDeltaTime;
		}

	}

}


