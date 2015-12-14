using UnityEngine;
using System.Collections;

public class TappableWeight : Tappable
{

	public override void OnClick ()
	{
		base.rigidBody.isKinematic = false;
	}
}
