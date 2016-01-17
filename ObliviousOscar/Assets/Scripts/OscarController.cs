﻿using DG.Tweening;
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
		Camera.main.transform.SetParent (null);
		oscar.GetComponent<SpriteRenderer> ().material.DOFade (0f, killDuration);
		oscar.transform.DOMove (new Vector3 (oscar.transform.position.x, oscar.transform.position.y + killHeight), killDuration)
			.OnComplete (
			() => {
				LivesManager.Instance.RemoveOneLife ();
				LevelManager.ReloadCurrent ();
			}
		);
	}

	public void StopOscarAndSayHi ()
	{
		oscar.IsAnimationEnabled = false;
		oscar.Sprite = oscar.finalSprite;
		oscar.IsRunning = false;
	}

	public void ReverseDirection ()
	{
		oscar.FlipDirection ();
		oscar.IsAnimationEnabled = true;
		oscar.IsRunning = true;
		oscar.Sprite = oscar.InitialSprite;
	}
}
