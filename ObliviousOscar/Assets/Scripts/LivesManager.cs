using UnityEngine;
using UnityEngine.UI;

public class LivesManager : PersistentSingleton<LivesManager>
{
	public Sprite halfHeart;
	public Sprite emptyHeart;

	int lives;
	Image[] hearts;

	void Start ()
	{
		hearts = UI.Instance.heartsPanel.GetComponentsInChildren<Image> ();

		lives = hearts.Length * 2;
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
}
