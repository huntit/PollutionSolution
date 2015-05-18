using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour 
{
////	public float fadeSpeed = 1.5f;
////
//	private bool sceneStarting = true;
////
////
////	void Awake()
////	{
////		GUITexture.Equals = new Rect (0f, 0f, Screen.width, Screen.height);
////	}
////	// Use this for initialization
////	
////	// Update is called once per frame
//
//	void Update() 
//	{
//		if(sceneStarting) 
//		{
//			StartScene();
//		}
//
//	}
////
////	void FadeToClear()
////	{
////		GUITexture.color = Color.Lerp (GUITexture.color, Color.clear, fadeSpeed * Time.deltaTime);
////	}
////
////	void FadeToBlack()
////	{
////		GUITexture.color = Color.Lerp (GUITexture.color, Color.black, fadeSpeed * Time.deltaTime);
////	}
//	public void StartScene()
//	{
//		FadeToClear();
//		if (GUITexture.color.a <= 0.05f) 
//		{
//			GUITexture.color = Color.clear;
//			GUITexture.enabled = false;
//			sceneStarting = false;
//
//		}
//	
//	}
//
//	public void EndScene()
//	{
//		GUITexture.enabled = true;
//		FadeToBlack();
//
//		if (GUITexture.color.a <= 0.95f) 
//		{
//			Application.LoadLevel(1);
//		}
//	}
}
