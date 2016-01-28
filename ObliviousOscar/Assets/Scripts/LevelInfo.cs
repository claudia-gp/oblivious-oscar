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

	const float infoShowDuration = 2f;
	const float fadeDuration = 1f;

	void Start ()
	{
		infoPanel = UI.Instance.LevelInfo;
		line1 = UI.Instance.InfoLine1;
		line2 = UI.Instance.InfoLine2;
		line1.text = "Level " + World + "." + Level;
		line2.text = Name;

		StartCoroutine (ShowText ());
	}

	IEnumerator ShowText ()
	{
		yield return new WaitForSeconds (infoShowDuration);
			
		fade (line1, line2, infoPanel);
	}

	void fade (params Graphic[] toFade)
	{
		Tweener lastTweener = null;
		foreach (var g in toFade) {
			lastTweener = g.DOFade (0f, fadeDuration).SetEase (Ease.Linear);
		}
		lastTweener.OnComplete (() => Oscar.Instance.SetIdle (false));
	}
}
