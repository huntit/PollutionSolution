using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public Transform avatar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0.695f * avatar.position.x + 14.9f,
		                                 0.235f * avatar.position.y + 6.5f, 6f);
	}
}
