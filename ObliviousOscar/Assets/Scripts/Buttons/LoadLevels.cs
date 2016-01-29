using UnityEngine;

public class LoadLevels : MonoBehaviour
{

	public void Tutorial ()
	{
		LevelManager.Load (LevelManager.Story);
	}

	public void Level1_2 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 1.2");
	}

	public void Level1_3 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 1.3");
	}

	public void Level1_4 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 1.4");
	}

	public void Level1_5 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 1.5");
	}

	public void Level2_1 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 2.1");
	}

	public void Level2_2 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 2.2");
	}

	public void Level2_3 ()
	{
		LevelManager.LoadAfterLoadingScreen ("Level 2.3");
	}

}