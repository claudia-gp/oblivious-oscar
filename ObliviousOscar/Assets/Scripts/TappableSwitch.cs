using UnityEngine;
using System.Collections;

public class TappableSwitch : Tappable
{

	public GameObject doorToOpen;

	public override void OnTap ()
	{
		Destroy (doorToOpen.GetComponent<BoxCollider2D> ());
	}
}
