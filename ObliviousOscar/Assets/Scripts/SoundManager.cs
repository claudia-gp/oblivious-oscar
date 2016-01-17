using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
	AudioSource audioSource;

	public AudioClip Switch;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void Play (AudioClip clip)
	{
		audioSource.PlayOneShot (clip);
	}
}
