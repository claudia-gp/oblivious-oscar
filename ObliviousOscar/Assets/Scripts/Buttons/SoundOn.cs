using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOn : MonoBehaviour {

	public GameObject SoundButtonOff;
	public GameObject SoundButtonOn;

	public void OnClick(){
		
		//Deactivate sound	
		SoundButtonOff.SetActive (true);
		SoundButtonOn.SetActive (false);
	}


}
