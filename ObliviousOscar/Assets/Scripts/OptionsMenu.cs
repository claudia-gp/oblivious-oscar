using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{
	public GameObject OptionsPanel;
	public GameObject PlayButton;
	public GameObject LevelsButton;
	public GameObject OptionsButton;
	public GameObject BackButton;

	public void show ()
	{
		OptionsPanel.SetActive (true);
		OptionsButton.SetActive (false);
		PlayButton.GetComponent<Button> ().enabled = false;
		LevelsButton.GetComponent<Button> ().enabled = false;
	}

	public void hide ()
	{
		OptionsPanel.SetActive (false);
		OptionsButton.SetActive (true);
		PlayButton.GetComponent<Button> ().enabled = true;
		LevelsButton.GetComponent<Button> ().enabled = true;
	}



}
