using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public GameObject SoundButtonOn; 
	public GameObject SoundButtonOff; 


	public void SoundOn(){

		//Deactivate sound	
		SoundManager.Instance.SetMusic(false);
		SoundButtonOff.SetActive (true);
		SoundButtonOn.SetActive (false);
	}
	
	public void SoundOff(){

		//Activate Sound
		SoundManager.Instance.SetMusic(true);
		SoundButtonOn.SetActive(true);
		SoundButtonOff.SetActive(false);


	}
}
