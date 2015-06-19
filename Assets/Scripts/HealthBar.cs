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
	// Creates the fillImage for the health bar slider to access; is a vital indicator of health information
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

			// if health is less than 30, change colour to red
			else if (health <= 30f) 
			
			{
				fillImage.color = new Color(1.0f, 0f, 0f);

				// When health is less than 30, play warning sound loop
				if (!audio.isPlaying) 
				{ 
					// Volume gets louder as health reduces
					audio.volume = 1f - health / 100f;
					audio.Play(); 
				}	
			}

			// If health is less than 50, change colour to orange
			else if (health <= 50f) 
			{
				fillImage.color = new Color(1.0f, 0.6f, 0f);
				// Stop playing low health warning sound
				audio.Stop();
			} 

			else // Else change colour to green in every other case
			{
				fillImage.color = new Color(0f, 1.0f, 0f);

				// Stop playing low health warning sound
				audio.Stop();	
			}
		}
	}
	// Gets the UI component Slider
	void Start() 
	{
		healthSlider = GetComponent<Slider>();
	}
}