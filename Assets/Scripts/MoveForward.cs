using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float speed = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * speed, GetComponent<Rigidbody2D>().velocity.y);
//		transform.Translate(transform.localScale.x * Time.deltaTime, 0, 0);
//		GetComponent<Rigidbody2D>().AddForce(new Vector2 (transform.localScale.x, 0) * 1000f);

	}

}
