using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	bool isPoisonous;

	// Use this for initialization
	void Start() 
	{
	}
	
	// Update is called once per frame
	void Update() 
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Avatar"))
		{
			Debug.Log("Collided with Avatar");
			Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
			//  (new Vector2(transform.localScale.x, transform.localScale.y))
			rb.AddForce(Vector2.right * 1000f);

//			GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.1f, 0.8f, 0.8f);
			StartCoroutine(BlinkSprite(0.2f, 3, new Color(0.8f, 0.1f, 0.8f, 0.8f)));
		}
	}


	IEnumerator BlinkSprite(float delayBetweenBlinks, int numberOfBlinks, Color blinkColor)
	{
		Color originalColor = GetComponent<SpriteRenderer>().color;

		bool canTakeDamage = false;
		float elapsedTime = 0f;
		int blinks = 0;
			
		while (blinks < numberOfBlinks * 2)
		{
//			Debug.Log("Elapsed time = " + elapsedTime + " < time = " + time + " deltaTime " + Time.deltaTime);
//			mat.color = colors[index % 2];				
//			elapsedTime += Time.deltaTime;
//			blinks++;
			gameObject.GetComponent<SpriteRenderer>().color = (blinks % 2 == 0) ? blinkColor : originalColor;
			blinks++;
			yield return new WaitForSeconds(delayBetweenBlinks);
		}
		gameObject.GetComponent<SpriteRenderer>().color = originalColor;
		canTakeDamage = true;
	}



}
