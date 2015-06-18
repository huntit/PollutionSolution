using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {
	
	private Animator animator;
	
	private bool readyToAttack;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D(Collider2D target){
		if (target.gameObject.tag == "Avatar") 
		{
			if(readyToAttack)
			{
				var explode = target.GetComponent<Explode>() as Explode;
				explode.OnExplode();
				
			}
			else
			{
				animator.SetInteger ("AnimState", 1);
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D target)
	{
		readyToAttack = false;
		animator.SetInteger ("AnimState", 0);
	}
	
	void Attack()
	{
		readyToAttack = true;
	}
}
