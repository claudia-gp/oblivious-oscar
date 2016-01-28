using UnityEngine;
using DG.Tweening;

public class SavePoint : OscarEnterDetecter
{
	const float scale = 1.5f;
	const float duration = 0.3f;

	protected override void OnOscarEnter ()
	{
		Oscar.Instance.UpdateLatestState ();
		SoundManager.Instance.Play (SoundManager.Instance.SavePoint);
		//transform.DOScale (scale, duration).SetEase (Ease.Linear);
		GetComponent<SpriteRenderer> ().DOColor (Color.white, duration);
	}
}
