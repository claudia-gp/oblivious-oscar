using UnityEngine;
using System.Collections;

public class TappableMagnet : Tappable
{
	DistanceJoint2D dj;
	public override void OnTap ()
	{

		Debug.Log("asdfd");
		dj = GetComponent<DistanceJoint2D> ();
		dj.distance = 0;


	}
	
}
