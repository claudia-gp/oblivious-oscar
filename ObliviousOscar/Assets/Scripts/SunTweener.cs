using UnityEngine;
using DG.Tweening;
using System.Collections;

public class SunTweener : MonoBehaviour
{
	const float duration = 0.5f;
	const float scale = 1.06f;
	const float pause = 0.7f;
	const Ease ease = Ease.InSine;

	void Start ()
	{
		StartCoroutine (SunTweenBig ());
	}

	IEnumerator SunTweenBig ()
	{
		yield return new WaitForSeconds (pause);
		transform.DOScale (scale, duration).SetEase (ease).OnComplete (
			() => StartCoroutine (SunTweenSmall ())
		);
	}

	IEnumerator SunTweenSmall ()
	{
		yield return new WaitForSeconds (0f);
		transform.DOScale (1f, duration).SetEase (ease).OnComplete (
			() => StartCoroutine (SunTweenBig ())
		);
	}

}
