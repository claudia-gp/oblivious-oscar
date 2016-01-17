﻿using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
	AudioSource audioSource;

	public AudioClip Switch;
	public AudioClip Explosion;
	public AudioClip SavePoint;
	public AudioClip MagnetActive;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void Play (AudioClip clip)
	{
		audioSource.PlayOneShot (clip);
	}
}
