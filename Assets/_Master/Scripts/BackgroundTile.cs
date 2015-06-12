using UnityEngine;
using System.Collections;

public class BackgroundTile : MonoBehaviour {

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		Debug.Log ("Background x start = " + transform.position.x + ". Background x end = " + transform.position.x + sr.bounds.size.x);
		Debug.Log ("Camera x = " + Camera.main.transform.position.x);

	}
}
