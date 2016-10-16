using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	
	public float soundToPlay = -1.0f; //this with designate which sound to play. -1 means don't play any sound. This is a float because then the animation window can access it. 
	public AudioClip[] audioClip; //this holds the sounds
	AudioSource audio;//for holding the audio source


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void Update () { //put the following in update
		if (soundToPlay > -1.0f) {//if the sound is greater than the value for not playing a sound 
			PlayAudio((int) soundToPlay, 1);//play the sound, casting the float to an int so that the audio source can use it 
			soundToPlay = -1.0f;//set it back to zero to keep this from looping back around and playing the sound again. 
		} 
	}

	void PlayAudio(int clip, float volumeScale){ 
		audio.PlayOneShot (audioClip [clip], volumeScale);//play the sound with the designated clip and volume scale
	}
}
