using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {
	private float healthAmount = 10f;
	public HealthBar healthBar;
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
//			healthBar.IncreaseHealth(healthAmount);
			// Play pickup sound
			Destroy(gameObject);
		}
	}
}
