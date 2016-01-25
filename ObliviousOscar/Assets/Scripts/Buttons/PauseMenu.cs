using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject PausePanel;
	public GameObject ButtonPanel;
	public GameObject HeartsPanel;
	public GameObject PauseButton;

	float initialTimeScale;

	void Awake ()
	{
		initialTimeScale = Time.timeScale;
	}

	public void Pause ()
	{
		Time.timeScale = 0f;

		PausePanel.SetActive (true);
		ButtonPanel.SetActive (false);
		HeartsPanel.SetActive (false);

	}

	public  void Exit ()
	{
		HeartsPanel.SetActive (true);
		PauseButton.SetActive (true);
		PausePanel.SetActive (false);
		LevelManager.Load (LevelManager.MainMenu);
	}

	public void Continue ()
	{
		Time.timeScale = initialTimeScale;

		PausePanel.SetActive (false);
		ButtonPanel.SetActive (true);
		HeartsPanel.SetActive (true);
	}

}

