using UnityEngine;
using System.Collections;

public class AirCanister : MonoBehaviour {
	private float airAmount = 10f;
	public AirBar airBar;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Avatar"))
		{
//			airBar.IncreaseAir(airAmount); uncomment when airBar works
			// Play pickup sound
			Destroy(gameObject);
		}
	}
}
