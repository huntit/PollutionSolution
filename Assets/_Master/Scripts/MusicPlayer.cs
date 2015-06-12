using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour 
{
	// Singleton pattern to prevent multiple music player instances. 
	static MusicPlayer instance = null;
	
	void Awake(){
		// Only allow one instance of a music track to play. Destroy new instances of the Music Player.
		if (instance != null)
		{
			Destroy (gameObject);
		} 
		else 
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
