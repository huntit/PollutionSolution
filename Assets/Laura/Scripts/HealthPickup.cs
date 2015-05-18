using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{

	public HealthBar healthBar;

	// Use this for initialization
	void Start() 
	{
//		healthBar.SetHealth (50f);
		//healthBar.Health = healthBar.Health -80f;


	}

	// Update is called once per frame
	void Update() 
	{
		healthBar.Health = healthBar.Health - 10f * Time.deltaTime;

	}
}
