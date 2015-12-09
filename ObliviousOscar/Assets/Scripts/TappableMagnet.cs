using UnityEngine;
using System.Collections;

public class TappableMagnet : Tappable
{
	public override void OnTap ()
	{
		GetComponent<DistanceJoint2D> ().distance = 0;
	}
	
}
