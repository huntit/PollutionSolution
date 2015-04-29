using UnityEngine;
using System.Collections;

public class AirBar : MonoBehaviour {
	private float air = 5;

	// Use this for initialization
	void Start()
	{
		air = 100;
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

	public void ReduceAir(float amount)
	{
//		air = air - amount
//			DrawAirBar()
	}
//			
	public void IncreaseAir(float amount)
	{
//			air = air + amount
//			DrawAirBar()
	}
	
	// Update is called once per frame

	void DrawAirBar()
	{
		//changes the scale of the air bar
	}


}
