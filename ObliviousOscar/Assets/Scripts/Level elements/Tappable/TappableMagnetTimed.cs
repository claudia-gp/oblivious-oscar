using UnityEngine;
using System.Collections;

public class TappableMagnetTimed : Tappable
{

	public float initDistance;
	public float delay = 0.5f;
	bool isActivated = false;
	DistanceJoint2D dj;
	Animator animator;
	bool soundPlayed;

	void Start ()
	{
		dj = GetComponent<DistanceJoint2D> ();
		animator = GetComponent<Animator> ();
	}

	public override void OnTap ()
	{
		if (!soundPlayed) {
			SoundManager.Instance.Play (SoundManager.Instance.MagnetActive);
			soundPlayed = true;
		}

		if (!isActivated) {
			dj.distance = 0;
			isActivated = true;
			StartCoroutine (WaitAndFall ());
			animator.SetFloat ("SpeedMultiplier", 1f / delay);
			animator.enabled = true;
		} 
	}

	IEnumerator WaitAndFall ()
	{
		yield return new WaitForSeconds (delay);
		dj.distance = initDistance;
		isActivated = false;
	}
}
