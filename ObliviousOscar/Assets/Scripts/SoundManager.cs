using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
	AudioSource audioSource;

	public AudioClip Switch;
	public AudioClip Explosion;
	public AudioClip SavePoint;
	public AudioClip MagnetActive;
	public AudioClip Winning;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void Play (AudioClip clip)
	{
		audioSource.PlayOneShot (clip);
	}

	public void SetMusic (bool musicOn)
	{
		if (musicOn) {
			audioSource.Play ();
		} else {
			audioSource.Stop ();
		}
	}
}
