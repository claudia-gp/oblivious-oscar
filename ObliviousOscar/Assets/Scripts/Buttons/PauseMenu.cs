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


	}

	public  void Exit ()
	{
		Time.timeScale = initialTimeScale;
		PausePanel.SetActive (false);
		LevelManager.Load (LevelManager.MainMenu);
	}

	public void Continue ()
	{
		Time.timeScale = initialTimeScale;

		PausePanel.SetActive (false);


	}

}

