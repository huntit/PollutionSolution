using UnityEngine;
using System.Collections;

public class enemy: MonoBehaviour
{
	private int health = 10;
	
	public int Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
			if (value < 1)
			{
				Debug.Log("AAAAAAAAARGH!");
			}
		}
	}
}
