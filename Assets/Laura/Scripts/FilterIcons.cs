using UnityEngine;
using System.Collections;

public class FilterIcons : MonoBehaviour 
{
	public float filterPieceCount = 0f;
	//		filterPartCollected(0)
	//		filterPartCollected(1)
	//		filterPartCollected(2)
	//		filterPartCollected(3)

	public bool[] filterPartsCollected;
	// Use this for initialization
	void Start () 
	{
//		//Each piece of filter is placed permanently onto the level, set to Trigger
//		//these are the sprites that show on HUD screen
//		Set all FilterPartSprites to 50% saturation
//		filterPartsCollected = new bool[] {false, false, false, false};
	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}

	public void DrawFilterPartsCollected()
	{
//		displays each piece of the filter when each piece is collected
//		for each item in filterPartCollected, 
//		change saturation of FilterPartSprites to 100%
	}

	public void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Avatar")
			Debug.Log ("Collected filter piece!");
			Destroy (gameObject);
	}
		
}

		