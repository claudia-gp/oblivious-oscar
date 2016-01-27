using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class LevelInfo : UnitySingleton<LevelInfo>
{
	public int World;
	public int Level;
	public string Name;

	Text line1, line2;
	Image infoPanel;

	void Start ()
	{
		infoPanel = UI.Instance.LevelInfo;
		line1 = UI.Instance.InfoLine1;
		line2 = UI.Instance.InfoLine2;
		line1.text = "World " + World;
		line2.text = "Level " + Level + ": " + Name;

		StartCoroutine (ShowText ());
	}

	IEnumerator ShowText ()
	{
		const float fadeDuration = 2f;
		
		yield return new WaitForSeconds (2f);
		Oscar.Instance.IsRunning = true;
			
		line1.DOFade (0f, fadeDuration);
		line2.DOFade (0f, fadeDuration);
		infoPanel.DOFade (0f, fadeDuration);
	}
}
