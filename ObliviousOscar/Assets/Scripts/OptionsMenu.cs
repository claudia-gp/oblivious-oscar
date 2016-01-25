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

	public void OnClick ()
	{
		OptionsPanel.SetActive (true);
		OptionsButton.SetActive (false);
		BackButton.SetActive (true);
		PlayButton.GetComponent<Button> ().enabled = false;
		LevelsButton.GetComponent<Button> ().enabled = false;
	}
}
