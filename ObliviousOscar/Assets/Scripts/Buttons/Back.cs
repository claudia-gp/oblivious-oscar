using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {


	public GameObject PausePanel;
	public GameObject PauseButton;
	public GameObject oscar;


	public void Back2MainMenu () {
	
		LevelManager.Load ("Main Menu");

	}
	

	public void Back2WorldScene () {
	
		LevelManager.Load ("Choose World Scene");

	}


	public void Exit(){

		PauseButton.SetActive (true);
		PausePanel.SetActive (false);
		oscar.SetActive(true);

		LevelManager.Load ("Main Menu");


	}
}
