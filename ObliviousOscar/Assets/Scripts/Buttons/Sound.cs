using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public GameObject SoundButtonOn; 
	public GameObject SoundButtonOff;
	public GameObject MusicButtonOn;
	public GameObject MusicButtonOff;


	public void SoundOn(){

		//Deactivate sound	
		SoundManager.Instance.SetMusic(false);
		SoundManager.Instance.SetSound (false);
		changeAspectOn ();
	}
	
	public void SoundOff(){

		//Activate Sound
		SoundManager.Instance.SetMusic(true);
		SoundManager.Instance.SetSound (true);
		changeAspectOff();


	}

	public void OptionsSoundOn(){

		//Deactivate sound	
		SoundManager.Instance.SetSound(false);
		changeAspectOn ();
	}

	public void OptionsSoundOff(){

		//Activate Sound
		SoundManager.Instance.SetSound(true);
		changeAspectOff ();


	}

	public void OptionsMusicOn(){

		//Deactivate sound	
		SoundManager.Instance.SetMusic(false);
		MusicButtonOff.SetActive (true);
		MusicButtonOn.SetActive (false);
	}

	public void OptionsMusicOff(){

		//Activate Sound
		SoundManager.Instance.SetMusic(true);
		MusicButtonOn.SetActive(true);
		MusicButtonOff.SetActive(false);


	}

	void changeAspectOn(){

		SoundButtonOff.SetActive (true);
		SoundButtonOn.SetActive (false);
		
	}

	void changeAspectOff(){

		SoundButtonOn.SetActive(true);
		SoundButtonOff.SetActive(false);
		
	}

}
