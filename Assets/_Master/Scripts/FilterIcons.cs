/* 
 * FilterIcons Script by Laura Yarnold
 * 
 * Displays filter items to be collected on the GUI screen. Alpha changes from 25% to 100% when filter item is collected.
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FilterIcons : MonoBehaviour 
{
	// Sets up number of filter icons collected to be set to 0; used to count how many Filter Items have been collected
	public static int filterCount = 0;

	// Sets collected number of filter icons to be false (none are collected)
	private bool collected = false;

	// If a Filter Item is collected, the alpha of the corrosponding Filter icon will be set to be fully visible
	public bool Collected
	{
		get { return collected; }
		
		set
		{
			collected = value;
			if (collected)
			{
				// Sets the alpha of the Filter icon to full, and adds to the filter count
				Color currentColor = gameObject.GetComponent<Image>().color;
				gameObject.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
				filterCount++;
			}
		}
	}


	// When initializatiing the game, finds the colour of each filter icon and set the alpha to 25%
	void Start() 
	{
		Color currentColor = gameObject.GetComponent<Image>().color;
		gameObject.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.25f);
	}
}

		