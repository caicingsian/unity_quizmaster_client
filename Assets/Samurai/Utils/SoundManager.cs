using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance;
	public static SoundManager instance { get{ return _instance; } }

	public AudioClip[] clips;
	public AudioSource soundPlayer;
	public AudioSource musicPlayer;

	void Awake(){

		if (_instance != null) {
			Destroy (gameObject);
			return;
		}
		_instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public static void PlaySound( string name ){
		AudioClip clip = GetAudioClip (name);
		if (clip != null) {
			_instance.soundPlayer.clip = clip;
			_instance.soundPlayer.Play ();
		}
	}

	private static AudioClip GetAudioClip( string name ){

		for (int i = 0; i < _instance.clips.Length; i++) {
			if (_instance.clips [i].name == name)
				return _instance.clips[i];
		}
		return null;
	}
}
