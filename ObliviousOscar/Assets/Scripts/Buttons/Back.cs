using UnityEngine;

public class Back : MonoBehaviour
{
	public bool OnIpad = false;
	public GameObject PausePanel;
	public GameObject PauseButton;
	public GameObject oscar;
	public  void LoadStage ()
	{
		PauseButton.SetActive (true);
		PausePanel.SetActive (false);
		oscar.SetActive(true);
		if (OnIpad) {
			LevelManager.Load ("Main Menu 1");
		} else {
			LevelManager.Load ("Main Menu");
		
		}
	}
}
