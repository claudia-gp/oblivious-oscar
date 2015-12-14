using UnityEngine;
using System.Collections;

public class TappableMagnet : Tappable
{
	private bool isActivated = false;

	public override void OnClick ()
	{
		if (isActivated == false) {
			GetComponent<DistanceJoint2D> ().distance = 0;
			isActivated = true;
		} else {
			GetComponent<DistanceJoint2D> ().distance = 3.4f;
			isActivated = false;
		}
	}
	
}
