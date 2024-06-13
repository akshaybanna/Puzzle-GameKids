using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


	public AudioClip [] animalsound;
	public AudioClip[] vegetablesound;
	public AudioClip [] fruitsound;
	public AudioClip [] bakerysound;

	public static SoundManager instance;

	public AudioSource CameraSound;

	
	public AudioClip springSound;
	public AudioClip baloonSoundPOP;
	
	
	public AudioClip Exploresound;
	public AudioClip Pullsound;

	public AudioSource ButtonSound;

	public AudioClip complete_sound;

	public AudioClip partAttach;


	void Awake()
	{
		instance = this;
	}
	
	public void PlaySound(int index)
	{
		CameraSound.clip = animalsound [index];
		CameraSound.Play ();
	}
	public void vegSound(int index) 
	{
		CameraSound.clip = vegetablesound[index];
		CameraSound.Play();
	}
	public void fruitssound(int index)
	{
		CameraSound.clip = fruitsound[index];
		CameraSound.Play();
	}
	public void bakerySound(int index)
	{
		CameraSound.clip = bakerysound[index];
		CameraSound.Play();
	}

	public void partAttachsound()
	{
		GetComponent<AudioSource> ().clip = partAttach;
		GetComponent<AudioSource>().Play ();
	}

	public void  levelcompletesound()
	{
		GetComponent<AudioSource> ().clip = complete_sound;
		GetComponent<AudioSource>().Play ();
	}
	public void ExploresoundPlay()
	{
		GetComponent<AudioSource> ().clip = Exploresound;
		GetComponent<AudioSource>().Play ();
	}

	public void pullsoundPlay()
	{
		if (!GetComponent<AudioSource> ().isPlaying) {
			GetComponent<AudioSource> ().clip = Pullsound;
			GetComponent<AudioSource> ().Play ();
		}
	}
	public void springaudio()
	{
		GetComponent<AudioSource>().clip = springSound;
		GetComponent <AudioSource>().Play ();

    }
	public void BalloonPop()
	{
        GetComponent<AudioSource>().clip = baloonSoundPOP;
        GetComponent<AudioSource>().Play();
    }

	public void soundOFF()
	{
		AudioListener.pause = true;
	}

	public void soundON()
	{
		AudioListener.pause = false;
	}

}
