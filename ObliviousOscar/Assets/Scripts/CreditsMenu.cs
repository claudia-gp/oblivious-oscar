using UnityEngine;
using System.Collections;

public class CreditsMenu : MonoBehaviour {
	public void show ()
	{
		LevelManager.Load (LevelManager.Credits);
	}

	public void hide ()
	{
		LevelManager.Load (LevelManager.MainMenu);
	}
}
