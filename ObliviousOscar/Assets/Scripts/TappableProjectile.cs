using UnityEngine;
using System.Collections;

public class TappableProjectile : Tappable {

	public override void OnTap ()
	{
		Destroy (gameObject);
	}
}
