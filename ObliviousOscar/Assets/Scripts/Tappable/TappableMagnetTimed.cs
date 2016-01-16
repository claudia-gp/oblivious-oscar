using UnityEngine;
using System.Collections;

public class TappableMagnetTimed : Tappable
{

	public float initDistance;
	public float delay = 0.5f;
	bool isActivated = false;
	DistanceJoint2D dj;
	Animator animator;

	void Awake ()
	{
		dj = GetComponent<DistanceJoint2D> ();
		animator = GetComponent<Animator> ();
	}

	public override void OnClick ()
	{
		if (isActivated == false) {
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
