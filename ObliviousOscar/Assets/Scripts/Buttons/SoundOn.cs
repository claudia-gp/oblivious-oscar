using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOn : MonoBehaviour {

	public GameObject SoundButtonOff;
	public GameObject SoundButtonOn;

	public void OnClick(){
		
		//Deactivate sound	
		SoundManager.Instance.SetMusic(false);
		SoundButtonOff.SetActive (true);
		SoundButtonOn.SetActive (false);
	}


}
