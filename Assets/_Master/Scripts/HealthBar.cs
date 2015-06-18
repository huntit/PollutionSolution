/* 
 * HealthBar Script by Laura Yarnold
 * 
 * Updates on-screen slider health bar
 * 
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{

	private Slider healthSlider;
	private float health = 100f;

	public Image fillImage;
	public GameManager gameManager;

	public float Health
	{
		get { return health; }

		set
		{
			// keep the health to be between 0 and 100
			health = Mathf.Clamp(value, 0f, 100f);

			// update the slider with health value
			healthSlider.value = Health;

			AudioSource audio = GetComponent<AudioSource>();	// get a reference to the AudioSource on this object

			// if health is zero, then die
			if (value <= 0f)
			{
				audio.Stop();	// don't play low health warning sound
				gameManager.LoseGame();

				//load level, reset health to 100f
			} 
			else if (health <= 30f) // change colour to red
			{
				fillImage.color = new Color(1.0f, 0f, 0f);

				// health is low, so play warning sound loop
				if (!audio.isPlaying) 
				{ 
					audio.volume = 1f - health/100f;	// volume should get louder as health reduces
					audio.Play(); 
				}	
			}
			else if (health <= 50f) // change colour to orange
			{
				fillImage.color = new Color(1.0f, 0.6f, 0f);
				audio.Stop();	// don't play low health warning sound
			} 
			else // change colour to green
			{
				fillImage.color = new Color(0f, 1.0f, 0f);
				audio.Stop();	// don't play low health warning sound
			}
		}


	}

	void Start() 
	{
		healthSlider = GetComponent<Slider>();
	}

}