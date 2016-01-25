using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

	public GameObject OptionsPanel;
	public GameObject PlayButton;
	public GameObject LevelsButton;

	public void OnClick()
	{
		OptionsPanel.SetActive(true);
		PlayButton.GetComponent<Button> ().enabled = false;
		LevelsButton.GetComponent<Button> ().enabled = false;
	}


}
