using UnityEngine;
using System.Collections;

public class PeterPlayer : MonoBehaviour {

	public float speed = 10f;
	public float jumpForce = 10f;

	public Transform groundedEnd;	// location to test for ground
	private bool isGrounded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal");
//		transform.Translate(horizontal * Time.deltaTime * speed, 0f, 0f);
		GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * speed, 0f));

		// Linecast straight down
//		groundedEnd.position = new Vector2(transform.position.x, transform.position.y - 1.0f);
		Vector2 groundPos = new Vector2(transform.position.x, transform.position.y - 1.0f);
		isGrounded = Physics2D.Linecast(this.transform.position, groundPos, 1 << LayerMask.NameToLayer("Ground")); 
//		Physics2D.Raycast(transform.position, -Vector2.up, 0.1);

		if (Input.GetKey("up") && isGrounded)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce),ForceMode2D.Force);
		}
	}
}
