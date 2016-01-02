using UnityEngine;
using DG.Tweening;

public class OscarController
{
	const float inversionCameraMovementDuration = 2f;
	public float inversionDistance = 5f;

	OscarController () {}

	static OscarController instance;

	public static OscarController Instance {
		get {
			if (instance == null) {
				instance = new OscarController ();
			}
			return instance;
		}
	}

	public void Kill ()
	{
		HeartsCounter.RemoveALife ();
		LevelManager.ReloadCurrent ();
	}

	public void StopOscarAndSayHi ()
	{
		Oscar.Instance.IsAnimationEnabled = false;
		Oscar.Instance.Sprite = Oscar.Instance.finalSprite;
		Oscar.Instance.IsRunning = false;
	}

	public void ReverseDirection ()
	{
		Camera.main.transform.parent = null;
		Oscar.Instance.GetComponent<Animator>().transform.Rotate(0,180,0);
		Oscar.Instance.Direction *= -1;
		Camera.main.transform.SetParent (Oscar.Instance.transform);	

		Oscar.Instance.IsAnimationEnabled = true;
		Oscar.Instance.IsRunning = true;
		Oscar.Instance.Sprite = Oscar.Instance.startSprite;
	}
}
