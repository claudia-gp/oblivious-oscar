using UnityEngine;
using System.Collections;

public class Switch : Tappable
{

	private Rigidbody2D rb;
	public GameObject doorToOpen;
	
	void Start ()
	{
		base.Start ();
		rb = GetComponent<Rigidbody2D> ();
	}

	public override void OnTap ()
	{
		BoxCollider2D bc = doorToOpen.GetComponent<BoxCollider2D> ();
		Destroy (bc);
	}
}
