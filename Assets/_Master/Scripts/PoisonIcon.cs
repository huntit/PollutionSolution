/* 
 * PoisonIcon Script by Laura Yarnold
 * 
 * 
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoisonIcon : MonoBehaviour 
{
	[Range(0, 10)] public float poisonTime = 2f;
	[Range(1, 20)] public float healthLossPerSec = 10f;
	public HealthBar healthBar;

	private bool poisoned;
	private float poisonFinishTime;

	public bool Poisoned
	{
		get { return poisoned; }
		
		set
		{
			poisoned = value;
				
			gameObject.GetComponent<Image>().enabled = poisoned;

			if (poisoned)
			{
				poisonFinishTime = Time.time + poisonTime;
				InvokeRepeating("BlinkIcon", 0f, 0.5f);
			} 
			else
			{
				CancelInvoke("BlinkIcon");
				gameObject.GetComponent<Image>().enabled = false;
			}
		}
	}

	private void Start()
	{
		Poisoned = false;
	}

	void FixedUpdate()
	{
		// If you are poisoned, lose health, and blink poisoned icon
		if (poisoned)
		{
			healthBar.Health -= healthLossPerSec * Time.fixedDeltaTime;

			// check if poison time is finished, set poisoned to false
			if (Time.time >= poisonFinishTime)
			{
				Poisoned = false;
			}
		}

	}

	// Blinks the poisoned icon on and off
	void BlinkIcon()
	{
		Debug.Log ("BlinkIcon !!!");
		gameObject.GetComponent<Image>().enabled = !gameObject.GetComponent<Image>().enabled;
	}
}