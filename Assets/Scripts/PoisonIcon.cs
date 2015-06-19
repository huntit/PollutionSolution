/* 
 * PoisonIcon Script by Laura Yarnold
 * 
 * Controls the poison icon that appears in the GUI. Also tells the health bar about the poison state.
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoisonIcon : MonoBehaviour 
{
	// Create a public range between 1 - 10 of how long you are poisoned
	[Range(0, 10)] public float poisonTime = 2f;

	// Create a public range between 1 - 20 of health loss per second
	[Range(1, 20)] public float healthLossPerSec = 10f;

	//Create a public healthbar that appears on GUI screen
	public HealthBar healthBar;

	//Create a boolean to tell the get/set if poisoned or not
	private bool poisoned;

	//Sets up a private float time for when poison should stop working
	private float poisonFinishTime;

	public bool Poisoned
	{
		//Returns whether poison is true or false
		get { return poisoned; }

		//If poisoned is enabled, blink the icon on and off for 4 seconds
		set
		{
			poisoned = value;
				
			gameObject.GetComponent<Image>().enabled = poisoned;

			if (poisoned)
			{
				poisonFinishTime = Time.time + poisonTime;
				StartCoroutine("BlinkIcon");
			} 

			else
			{
				//Else set the poison icon image to be invisible 
				gameObject.GetComponent<Image>().enabled = false;
			}
		}
	}

	//Sets poisoned to be false at the start of the game
	private void Start()
	{
		Poisoned = false;
	}

	void FixedUpdate()
	{
		// If you are poisoned, lose health over time
		if (poisoned)
		{
			healthBar.Health -= healthLossPerSec * Time.fixedDeltaTime;

			// Check if poison time is finished, then set poisoned to false
			if (Time.time >= poisonFinishTime)
			{
				Poisoned = false;
			}
		}

	}

	// Blinks the poisoned icon on and off
	IEnumerator BlinkIcon()
	{
		while (poisoned)
		{
			yield return new WaitForSeconds(0.4f);
			gameObject.GetComponent<Image>().enabled = false; // icon off
			yield return new WaitForSeconds(0.4f);
			gameObject.GetComponent<Image>().enabled = true; // icon on

		}

		// When no longer poisoned, turn poison icon off
		gameObject.GetComponent<Image>().enabled = false;
	}
}