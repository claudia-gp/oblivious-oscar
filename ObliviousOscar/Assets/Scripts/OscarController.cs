using DG.Tweening;
using UnityEngine;

public class OscarController
{
	const float inversionCameraMovementDuration = 2f;
	public float inversionDistance = 5f;

	OscarController () {}

	static OscarController instance;

	Oscar oscar;

	const float killDuration = 2f;
	const float killHeight = 4f;

	public static OscarController Instance {
		get {
			if (instance == null) {
				instance = new OscarController ();
			}
			instance.oscar = Oscar.Instance;
			return instance;
		}
	}

	public void Kill ()
	{
		oscar.IsRunning = false;
		oscar.Animator.SetBool (Oscar.AnimIsDead, true);
		Object.Destroy (oscar.GetComponent<Collider2D> ());
		Camera.main.transform.SetParent (null);
		oscar.GetComponent<SpriteRenderer> ().material.DOFade (0f, killDuration);
		LivesManager.Instance.RemoveOneLife ();
		oscar.transform.DOMove (new Vector3 (oscar.transform.position.x, oscar.transform.position.y + killHeight), killDuration)
			.OnComplete (LevelManager.ReloadCurrent);
	}

	public void ReverseDirection ()
	{
		oscar.FlipDirection ();
		oscar.SetIdle (false);
	}
}
