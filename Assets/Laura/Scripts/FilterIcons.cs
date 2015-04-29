using UnityEngine;
using System.Collections;

public class FilterIcons : MonoBehaviour {
	public bool[] filterPartsCollected;
	// Use this for initialization
	void Start () {
		filterPartsCollected = new bool[] {false, false, false, false};
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DrawFilterPartsCollected()
	{
		//Pass
	}
}
