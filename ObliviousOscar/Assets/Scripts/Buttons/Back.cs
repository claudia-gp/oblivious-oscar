using UnityEngine;

public class Back : MonoBehaviour
{
	public GameObject PausePanel;
	public GameObject PauseButton;

	public void Back2MainMenu ()
	{
		LevelManager.Load (LevelManager.MainMenu);
	}


	public void Back2WorldScene ()
	{	
		LevelManager.Load (LevelManager.ChooseWorld);
	}

	public void Exit ()
	{

		PauseButton.SetActive (true);
		PausePanel.SetActive (false);

		LevelManager.Load (LevelManager.MainMenu);
	}
}
