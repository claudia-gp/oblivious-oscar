using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOff : MonoBehaviour {

	public GameObject SoundButtonOn; 
	public GameObject SoundButtonOff; 


	public void OnClick(){
		
		//Activate Sound
		SoundButtonOn.SetActive(true);
		SoundButtonOff.SetActive(false);


	}



}
