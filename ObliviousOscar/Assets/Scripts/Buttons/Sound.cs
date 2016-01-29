using UnityEngine;

public class Sound : MonoBehaviour
{

	public GameObject SoundButtonOn;
	public GameObject SoundButtonOff;
	public GameObject MusicButtonOn;
	public GameObject MusicButtonOff;

	void Start(){

		if (SoundManager.Instance.SoundOn == false) {
			changeAspectOn ();

		}



		if (SoundManager.Instance.MusicOn == false) {
			MusicButtonOff.SetActive (true);
			MusicButtonOn.SetActive (false);
		}

	}



	public void SoundOn ()
	{
		//Deactivate sound	
		SoundManager.Instance.MusicOn = false;
		SoundManager.Instance.SoundOn = false;
		changeAspectOn ();
	}

	public void SoundOff ()
	{
		//Activate Sound
		SoundManager.Instance.MusicOn = true;
		SoundManager.Instance.SoundOn = true;
		changeAspectOff ();
	}

	public void OptionsSoundOn ()
	{
		//Deactivate sound	
		SoundManager.Instance.SoundOn = false;
		changeAspectOn ();
	}

	public void OptionsSoundOff ()
	{
		//Activate Sound
		SoundManager.Instance.SoundOn = true;
		changeAspectOff ();
	}

	public void OptionsMusicOn ()
	{
		//Deactivate sound	
		SoundManager.Instance.MusicOn = false;
		MusicButtonOff.SetActive (true);
		MusicButtonOn.SetActive (false);
	}

	public void OptionsMusicOff ()
	{
		//Activate Sound
		SoundManager.Instance.MusicOn = true;
		MusicButtonOn.SetActive (true);
		MusicButtonOff.SetActive (false);
	}

	void changeAspectOn ()
	{
		SoundButtonOff.SetActive (true);
		SoundButtonOn.SetActive (false);	
	}

	void changeAspectOff ()
	{
		SoundButtonOn.SetActive (true);
		SoundButtonOff.SetActive (false);
	}

}
