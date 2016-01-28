using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SavePoint : OscarEnterDetecter
{
	const float scale = 1.5f;
	const float duration = 0.3f;

	static IList alreadyActivated = new ArrayList ();

	SpriteRenderer sr;

	void Awake ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

	void Start ()
	{
		if (alreadyActivated.Contains (transform.position)) {
			sr.color = Color.white;
			Destroy (GetComponent<BoxCollider2D> ());
		}
	}

	protected override void OnOscarEnter ()
	{
		Oscar.Instance.UpdateLatestState ();
		SoundManager.Instance.Play (SoundManager.Instance.SavePoint);
		sr.DOColor (Color.white, duration);
		alreadyActivated.Add (transform.position);
	}

	public static void ResetSavePoints ()
	{
		alreadyActivated = new ArrayList ();
	}
}
