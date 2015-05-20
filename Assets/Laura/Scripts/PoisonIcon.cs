using UnityEngine;
using System.Collections;

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
				
			gameObject.GetComponent<SpriteRenderer>().enabled = poisoned;

			if (poisoned)
			{
				poisonFinishTime = Time.time + poisonTime;
			}
			
		}
	}

	private void Start()
	{
		Poisoned = false;
	}

	void FixedUpdate()
	{
		//If you are poisoned, lose health
		if (poisoned)
		{
			healthBar.Health -= healthLossPerSec * Time.fixedDeltaTime;
			//check if poison time is finished, set poisoned to false
			if (Time.time >= poisonFinishTime)
			{
				Poisoned = false;
			}
		}

	}
}