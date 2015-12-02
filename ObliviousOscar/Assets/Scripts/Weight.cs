using UnityEngine;
using System.Collections;

public class Weight : Tappable
{
	private Rigidbody2D rb;

	public void Start ()
	{
		base.Start ();
		rb = GetComponent<Rigidbody2D> ();
	}

	public override void OnTap ()
	{
		rb.isKinematic = false;
	}

}
