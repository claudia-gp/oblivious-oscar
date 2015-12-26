﻿using UnityEngine.SceneManagement;

public class OscarController
{
	private static OscarController instance;

	private OscarController ()
	{
	}

	public static OscarController Instance {
		get {
			if (instance == null) {
				instance = new OscarController ();
			}
			return instance;
		}
	}

	public void Kill ()
	{
		#if UNITY_5_3
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		#else
		Application.LoadLevel (Application.loadedLevel);
		#endif
	}

	public void StopOscarAndSayHi ()
	{
		Oscar.Instance.IsAnimationEnabled = false;
		Oscar.Instance.Sprite = Oscar.Instance.finalSprite;
		Oscar.Instance.IsRunning = false;
	}
}
