using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
	AudioSource audioSource;

	public AudioClip Switch;
	public AudioClip Explosion;
	public AudioClip SavePoint;
	public AudioClip MagnetActive;
	public AudioClip Winning;

	public bool SoundOn{ get; set; }

	bool _musicOn = true;

	public bool MusicOn {
		get { return _musicOn; } 
		set {
			_musicOn = value;
			if (value) {
				audioSource.Play ();
			} else {
				audioSource.Stop ();
			}
		}
	}

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void Play (AudioClip clip)
	{
		if (SoundOn) {
			audioSource.PlayOneShot (clip);
		}
	}
}
