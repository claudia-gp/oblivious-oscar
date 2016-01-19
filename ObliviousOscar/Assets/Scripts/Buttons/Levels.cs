using UnityEngine;

public class Levels : MonoBehaviour
{
	public bool OnIpad = false;

	public void LoadStage ()
	{
		if (OnIpad) {
			LevelManager.Load ("Choose World Scene 1");
		} else {
			LevelManager.Load ("Choose World Scene");
		}
	}

}
