using UnityEngine;
using System.Collections;

public class TappableMagnet : Tappable
{
	private bool isActivated = false;

	public bool tappableTwice;
	public float initDistance;

	public override void OnClick ()
	{
		if (isActivated == false) {
			GetComponent<DistanceJoint2D> ().distance = 0;
			isActivated = true;
		} else { if(tappableTwice){
			GetComponent<DistanceJoint2D> ().distance = initDistance;
			isActivated = false;
			}
		}
	}
	
}
