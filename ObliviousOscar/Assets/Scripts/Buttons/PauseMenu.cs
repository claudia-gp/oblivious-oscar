using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject PausePanel;
	public GameObject Oscar;
	public GameObject ButtonPanel;
	public GameObject HeartsPanel;
	public GameObject PauseMenuImage,PauseMenuImage2;
	public GameObject BackgroundImage;
	public GameObject LevelContainer;
	public GameObject PauseButton;
	public GameObject oscar;


    public void Pause()
    {
		PausePanel.SetActive(true);
		Oscar.SetActive (false);
		ButtonPanel.SetActive (false);
		HeartsPanel.SetActive(false);
		PauseMenuImage.SetActive(true);
		PauseMenuImage2.SetActive(true);
		BackgroundImage.SetActive(false);
		LevelContainer.SetActive(false);
    }

	public  void Exit ()
	{

		HeartsPanel.SetActive(true);
		PauseMenuImage.SetActive(false);
		PauseMenuImage2.SetActive(false);
		BackgroundImage.SetActive(true);
		LevelContainer.SetActive(true);
		PauseButton.SetActive (true);
		PausePanel.SetActive (false);
		oscar.SetActive(true);
		LevelManager.Load ("Main Menu");


	}

	public void Continue () {

		PausePanel.SetActive(false);
		Oscar.SetActive(true);
		ButtonPanel.SetActive (true);
		HeartsPanel.SetActive (true);
		BackgroundImage.SetActive(true);
		PauseMenuImage.SetActive(false);
		PauseMenuImage2.SetActive(false);
		LevelContainer.SetActive (true);
	}

}

