using UnityEngine;

public class Back : MonoBehaviour
{
	public bool OnIpad = false;
	public GameObject PausePanel;
	public  void LoadStage ()
	{
		PausePanel.SetActive (false);
		if (OnIpad) {
			LevelManager.Load ("Main Menu 1");
		} else {
			LevelManager.Load ("Main Menu");
		
		}
	}
}
