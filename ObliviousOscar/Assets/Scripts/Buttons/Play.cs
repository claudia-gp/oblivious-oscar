using UnityEngine;

public class Play : MonoBehaviour
{
	public void LoadStage ()
	{
		LevelManager.Load (LevelManager.Story);
	}
}
