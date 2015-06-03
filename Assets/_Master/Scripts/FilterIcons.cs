using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FilterIcons : MonoBehaviour 
{
	public float filterPieceCount = 0f;
	//		filterPartCollected(0)
	//		filterPartCollected(1)
	//		filterPartCollected(2)
	//		filterPartCollected(3)

	public bool[] filterPartsCollected;

	private bool collected = false;
	public bool Collected
	{
		get { return collected; }
		
		set
		{
			collected = value;
			if (collected)
			{
				// set to full alpha
				Color currentColor = gameObject.GetComponent<Image>().color;
				gameObject.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
			}
		}
	}


	// Use this for initialization
	void Start () 
	{
//		//Each piece of filter is placed permanently onto the level, set to Trigger
//		//these are the sprites that show on HUD screen
//		Set all FilterPartSprites to 50% saturation
		Color currentColor = gameObject.GetComponent<Image>().color;
		gameObject.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.25f);
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
	
}

		