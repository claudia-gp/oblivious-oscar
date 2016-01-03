﻿using UnityEngine;
using UnityEngine.UI;

public class LivesController : PersistentSingleton<LivesController>
{

	public Sprite halfHeart;
	public Sprite emptyHeart;

	int lives;
	Image[] hearts;

	static bool firstTime = true;

	void Start ()
	{
		if (firstTime) {
			firstTime = false;

			hearts = UI.Instance.heartsPanel.GetComponentsInChildren<Image> ();

			lives = hearts.Length * 2;
		}
	}

	public void RemoveOneLife ()
	{
		if (lives > 1) {
			lives--;
			hearts[lives / 2].overrideSprite = lives % 2 == 0 ? emptyHeart : halfHeart;
		} else {
			LevelManager.ResetLevel ();
			LevelManager.ReloadCurrent ();
		}
	}

	public override void Reset ()
	{
		firstTime = true;
		base.Reset ();
	}
}
