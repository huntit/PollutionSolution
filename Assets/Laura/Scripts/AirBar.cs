using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirBar : MonoBehaviour 
{
	public AirBar airBar;

	private Slider airSlider;
	private float air = 100f;

	// Use this for initialization
	void Start()
	{
		airSlider = GetComponent<Slider>();
	}

	void FixedUpdate()
	{
		//		// consume air while under water 
		//		if Avatar.inWater
		//		ReduceAir(amount * time.DeltaTime)
		//		// if out of air and under water, lose health
		//		if air <= 0
		//		HealthBar.ReduceHealth(amount * time.DeltaTime)
	}

	public float Air
	{
		get
		{
			return air;
		}
		set
		{
			air = value;
			
			//			transform.localScale = new Vector3(Health/100f, 1f, 1f);
			airSlider.value = Air;

			if (value <= 0f)
			{
				Debug.Log("AAAAAAAAARGH!");
			}

		}
	}

	public void IncreaseAir()
	{
		airBar.Air = airBar.Air - 10f * Time.deltaTime; 
	}
}


