using UnityEngine;
using System.Collections;

public class TappableMagnet : Tappable
{
	public bool tappableTwice;
	public float initDistance;
	bool isActivated = false;
	DistanceJoint2D dj;

	void Awake ()
	{
		dj = GetComponent<DistanceJoint2D> ();
	}

	public override void OnClick ()
	{
		if (isActivated == false) {
			dj.distance = 0;
			isActivated = true;
		} else if (tappableTwice) {
			dj.distance = initDistance;
			isActivated = false;
		}
	}
	
}
