using UnityEngine;
using System.Collections;

public class HealthBar2 : MonoBehaviour
{
	private float health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	public float GetHealth()
//	{
//		return health;
//	}
//
//	public void SetHealth(float value)
//	{
//		health = value;
//		//TODO: Rescale bar
//	}

	public float Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;

			transform.localScale = new Vector3(Health/100f, 1f, 1f);

			if (value <= 0f)
			{
				Debug.Log("AAAAAAAAARGH!");
			}
		}
	}
}
