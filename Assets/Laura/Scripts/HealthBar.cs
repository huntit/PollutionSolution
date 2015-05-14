using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
	private Slider healthSlider;
	private float health = 100f;

	//public float health = 100;

	// Use this for initialization
	void Start () 
	{
		healthSlider = GetComponent<Slider> ();
		//health = 100
			
		//ReduceHealth(float amount)
		//health = health - amount
		//DrawHealthBar()
		//
		//if health <= 0
		//GameManager.LoseGame()
		//
		//IncreaseHealth(float amount)
		//health = health + amount
		//DrawHealthBar()
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public float Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
			
//			transform.localScale = new Vector3(Health/100f, 1f, 1f);
			healthSlider.value = Health;
			
			if (value <= 0f)
			{
				Debug.Log("AAAAAAAAARGH!");
			}
		}
	}

//	void OnTriggerStay(Collider other) 
//	{
//		if (avatar && healthBarSlider.value > 0) 
//		{
//			healthBarSlider.value -= 0.011f;
//		}
//
//	}


	public void DrawHealthBar()
	{
		//changes the scale of the health bar depending on health
	}
}