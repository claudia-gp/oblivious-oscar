using UnityEngine;
using System.Collections;

public class TappableWeight : Tappable
{

	public override void OnTap ()
	{
		base.rigidBody.isKinematic = false;
	}
}
