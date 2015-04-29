using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
	//public float health = 100;

	// Use this for initialization
	void Start () 
	{
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

	public void IncreaseHealth(float amount)
	{
		Debug.Log (amount.ToString());
	}

	public void DrawHealthBar()
	{
		//changes the scale of the health bar depending on health
	}
}