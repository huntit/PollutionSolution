using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
	private Slider healthSlider;
	private float health = 100f;

	// Use this for initialization
	void Start () 
	{
		healthSlider = GetComponent<Slider>();
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
				//load level, reset health to 100f
			}

//			if ()
//			{
//				healhSlider.value = ;
//			}
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