using UnityEngine;
using System.Collections;

public class BackgroundTile : MonoBehaviour 
{
	private SpriteRenderer sr;

	void Start () 
	{
		sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () 
	{
	
		float camPosx = Camera.main.transform.localPosition.x;
		float bgStartx = transform.localPosition.x - (sr.sprite.bounds.size.x / 2f);
		float bgEndx = transform.localPosition.x + (sr.sprite.bounds.size.x / 2f);

		if (camPosx < bgStartx)
		{
			Debug.Log ("To the left of BG");
		}
		else if (camPosx > bgStartx)
		{
			Debug.Log ("To the right of BG");
		}
		else
		{
			Debug.Log ("In BG");
		}


	
		Debug.Log ("Background x start = " + bgStartx + ". Background x end = " + bgEndx);
		Debug.Log ("Camera x = " + camPosx);
	
		if (sr.isVisible)
		{
			Debug.Log ("Visible");
		}
		else
		{
			Debug.Log ("Not visible");
		}

	}
}
