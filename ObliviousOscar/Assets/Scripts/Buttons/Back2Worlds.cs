using UnityEngine;

public class Back2 : MonoBehaviour
{
	public bool OnIpad = false;

	public  void LoadStage ()
	{
		if (OnIpad) {
			LevelManager.Load ("Choose World Scene 1");
		} else {
			LevelManager.Load ("Choose World Scene");
		}

	}
}
