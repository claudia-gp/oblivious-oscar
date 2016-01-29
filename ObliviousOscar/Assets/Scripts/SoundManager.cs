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

	public bool MusicOn {
		get { return audioSource.isPlaying; } 
		set {
			if (value) {
				audioSource.Play ();
			} else {
				audioSource.Stop ();
			}
		}
	}

	protected new void Awake ()
	{
		base.Awake ();

		audioSource = GetComponent<AudioSource> ();
		SoundOn = true;
	}

	public void Play (AudioClip clip)
	{
		if (SoundOn) {
			audioSource.PlayOneShot (clip);
		}
	}
}
