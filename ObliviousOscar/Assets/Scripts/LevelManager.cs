using UnityEngine.SceneManagement;

public class LevelManager
{
	public const string MainMenu = "Main Menu";
	public const string ChooseWorld = "Choose World";
	public const string FirstLevel = "Level 1.1-Tutorial";
	public const string Loading = "Loading";
	public const string Story = "FirstStory";
	public const string Options = "Options";
	public const string Credits = "Credits";


	LevelManager () {}

	public static int CurrentIndex {
		get { return SceneManager.GetActiveScene ().buildIndex; }
	}

	public static int LevelCount {
		get { return SceneManager.sceneCountInBuildSettings; }
	}

	public static void Load (int index)
	{
		SceneManager.LoadScene (index);
	}

	public static void Load (string levelName)
	{
		SceneManager.LoadScene (levelName);
	}

	public static void LoadAfterLoadingScreen (string levelName)
	{
		SceneManager.LoadSceneAsync (Loading).allowSceneActivation = true;
		SceneManager.LoadSceneAsync (levelName).allowSceneActivation = true;
	}

	public static void ReloadCurrent ()
	{
		Load (CurrentIndex);
	}

	public static void ResetLevel ()
	{
		Oscar.Instance.ResetToInitialState ();
		LivesManager.Instance.Reset ();
		UI.Instance.Reset ();
		SavePoint.ResetSavePoints ();
	}
		
}
