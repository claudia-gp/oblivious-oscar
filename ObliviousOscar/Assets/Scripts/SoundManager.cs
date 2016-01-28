using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
	AudioSource audioSource;

	public AudioClip Switch;
	public AudioClip Explosion;
	public AudioClip SavePoint;
	public AudioClip MagnetActive;
	public AudioClip Winning;

	bool soundOn = true;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void Play (AudioClip clip)
	{
		if (soundOn) {
			audioSource.PlayOneShot (clip);
		}
	}

	public void SetMusic (bool musicOn)
	{
		if (musicOn) {
			audioSource.Play ();
		} else {
			audioSource.Stop ();
		}
	}

	public void SetSound (bool soundOn)
	{
		this.soundOn = soundOn;
	}
}
