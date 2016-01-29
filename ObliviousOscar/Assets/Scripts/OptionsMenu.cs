using UnityEngine;


public class OptionsMenu : MonoBehaviour
{
	public void show ()
	{
		LevelManager.Load (LevelManager.Options);
	}

	public void hide ()
	{
		LevelManager.Load (LevelManager.MainMenu);
	}
}
