using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	public GameObject PausePanel;
	public GameObject Oscar;
	public GameObject ButtonPanel;
	public GameObject HeartsPanel;
	public GameObject BackgroundImage;
	public GameObject PauseMenuImage1,PauseMenuImage2;
	public GameObject LevelContainer;

	public void OnClick () {

		PausePanel.SetActive(false);
		Oscar.SetActive(true);
		ButtonPanel.SetActive (true);
		HeartsPanel.SetActive (true);
		BackgroundImage.SetActive(true);
		PauseMenuImage1.SetActive(false);
		PauseMenuImage2.SetActive(false);
		LevelContainer.SetActive (true);
	}
}
