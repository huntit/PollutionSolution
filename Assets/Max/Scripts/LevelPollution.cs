using UnityEngine;
using System.Collections;

public class LevelPollution : MonoBehaviour {
	//GameObject gameObject;

	// Use this for initialization
	void Start () {
		//StartCoroutine (FadeScreen ());
		Color color = GetComponent<Renderer>().material.color;
		color.a = 0.9f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeScreen()
	{
		Color color = GetComponent<Renderer>().material.color;
		color.a = 0.5f;
		yield return new WaitForSeconds(1);
	}
}
