using UnityEngine;
using System.Collections;

public class TappableProjectile : Tappable {

	public override void OnClick ()
	{
		Destroy (transform.parent.gameObject);
	}
}
