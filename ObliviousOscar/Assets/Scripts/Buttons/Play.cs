using UnityEngine;

public class Play : MonoBehaviour
{
	public void LoadStage ()
	{
		LevelManager.LoadAfterLoadingScreen (LevelManager.FirstLevel);
	}
}
