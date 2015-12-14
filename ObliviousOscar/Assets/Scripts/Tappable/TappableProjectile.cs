using UnityEngine;
using System.Collections;

public class TappableProjectile : Tappable
{

	public override void OnClick ()
	{
		Destroy (gameObject);
	}

	public void OnPress ()
	{
		OnClick ();
	}

	public void OnDrag ()
	{
		OnClick ();
	}
}
