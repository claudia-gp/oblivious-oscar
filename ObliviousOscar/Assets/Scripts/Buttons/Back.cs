using UnityEngine;

public class Back : MonoBehaviour
{
	public bool OnIpad = false;

	public  void LoadStage ()
	{
		if (OnIpad) {
			LevelManager.Load ("Main Menu 1");
		} else {
			LevelManager.Load ("Main Menu");
		}
	}
}
