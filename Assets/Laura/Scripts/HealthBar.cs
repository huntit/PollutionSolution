using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{

	private Slider healthSlider;
	private float health = 100f;

	public Image fillImage;

	public float Health
	{
		get { return health; }

		set
		{
			// keep the health to be between 0 and 100
			health = Mathf.Clamp(value, 0f, 100f);

			// if health is zero, then die
			if (value <= 0f)
			{
				Debug.Log("AAAAAAAAARGH!");
				//load level, reset health to 100f
			} 
			// update the slider with health value
			healthSlider.value = Health;

			if (health <= 25f) // change colour to red
			{
				fillImage.color = new Color(1.0f, 0f, 0f);
			}
			else if (health <= 50f) // change colour to orange
			{
				fillImage.color = new Color(1.0f, 0.6f, 0f);
			} 
			else // change colour to green
			{
				fillImage.color = new Color(0f, 1.0f, 0f);
			}
		}


	}

	void Start() 
	{
		healthSlider = GetComponent<Slider>();
	}

}