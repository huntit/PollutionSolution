/* 
 * HealthBar Script by Laura Yarnold
 * 
 * Updates on-screen UI slider health bar; health bar is affected by touching ememies, poison and drowning. When health == 0, the avatar dies.
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
	// Creates the fillImage for the health bar slider to access; is a viaul indicator of health information
	public Image fillImage;

	// Sets the game manager to be gameManager; lets the healthBar script interact with the GameManager script
	public GameManager gameManager;

	// Creates a UI health bar slider that displays on the GUI
	private Slider healthSlider;

	// Sets health to full (100)
	private float health = 100f;

	//Contols the health of the avatar
	public float Health
	{
		get { return health; }

		set
		{
			// Keeps the health to be between 0 and 100
			health = Mathf.Clamp(value, 0f, 100f);

			// Updates the slider with health value
			healthSlider.value = Health;

			// Gets a reference to the AudioSource on this object
			AudioSource audio = GetComponent<AudioSource>();

			// If health is zero, then die
			if (value <= 0f)
			{
				// Stops the low health warning audio from playing
				audio.Stop();

				//Calls the game manager script to lose the game
				gameManager.LoseGame();
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