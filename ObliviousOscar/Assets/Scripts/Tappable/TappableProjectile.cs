using UnityEngine;
using System.Collections;

public class TappableProjectile : Tappable {

	public GameObject proj;
	public override void OnClick ()
	{
		Destroy (proj);
	}
}
