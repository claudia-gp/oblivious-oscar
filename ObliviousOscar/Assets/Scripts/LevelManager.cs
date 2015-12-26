using UnityEngine.SceneManagement;

public class LevelManager
{
	private LevelManager ()
	{
	}

	public static int CurrentIndex {
		get {
			return SceneManager.GetActiveScene ().buildIndex;
		}
	}

	public static int LevelCount {
		get {
			return SceneManager.sceneCountInBuildSettings;
		}
	}

	public static void Load (int index)
	{
		SceneManager.LoadScene (index);
	}

	public static void ReloadCurrent ()
	{
		Load (CurrentIndex);
	}
		
}
