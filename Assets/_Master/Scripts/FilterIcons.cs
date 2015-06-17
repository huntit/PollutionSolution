using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FilterIcons : MonoBehaviour 
{
	public float filterPieceCount = 0f;
	public static int filterCount = 0;
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
				filterCount++;
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
	}
}

		