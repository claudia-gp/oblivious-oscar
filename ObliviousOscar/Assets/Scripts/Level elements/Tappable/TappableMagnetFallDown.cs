using UnityEngine;
using System.Collections;

public class TappableMagnetFallDown : Tappable {

	public GameObject box;

	public override void OnTap ()
	{
		box.GetComponent<Rigidbody2D> ().isKinematic = false;
	}
}
