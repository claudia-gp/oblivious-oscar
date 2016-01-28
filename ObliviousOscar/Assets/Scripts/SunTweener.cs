using UnityEngine;
using DG.Tweening;

public class SunTweener : MonoBehaviour
{
	const float duration = 3f;
	const float scale = 1.3f;

	void Start ()
	{
		transform.DOScale (scale, duration).OnComplete (
			() => transform.DOScale (1f, duration).OnComplete (Start)
		);
	}

}
