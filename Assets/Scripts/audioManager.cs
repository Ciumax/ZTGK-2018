using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour {

	public string ambient;
	public static audioManager instance;
	public sound[] sounds;
	// Use this for initialization
	void Start () {
		Play (ambient);
	}


	void Awake () {
		/*if (instance = null) {
			instance = this;
		} else {
			Destroy (gameObject);
			return;
		} 
		DontDestroyOnLoad(gameObject);	*/
		foreach (sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip; 
			s.source.volume = s.volume; 
		}
	}
	
	// Update is called once per frame
	public void Play (string n) {
		sound s = Array.Find (sounds, sound => sound.name == n);
		if (s == null) {
			Debug.Log ("nie znaleziono pliku o nazwie " + n);
		}
		s.source.Play();
	}
}
