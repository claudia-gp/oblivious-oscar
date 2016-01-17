using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOn : MonoBehaviour {

	public GameObject SoundButtonOff;
	public GameObject SoundButtonOn;

	public void OnClick(){
		
		//Deactivate sound	
		AudioListener.pause = true;
		SoundButtonOff.SetActive (true);
		SoundButtonOn.SetActive (false);
	}


}
