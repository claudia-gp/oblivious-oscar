using UnityEngine;
using System;

public abstract class Tappable : MonoBehaviour
{
	protected Rigidbody2D rigidBody;
	protected new Collider2D collider;

	static readonly TimeSpan MinSpanBetweenTwoTouches = new TimeSpan (0, 0, 0, 0, 500);

	DateTime lastTime;

	protected void Awake ()
	{
		lastTime = DateTime.Now;

		collider = GetComponent<Collider2D> ();
		if (!(collider)) {
			collider = gameObject.AddComponent<BoxCollider2D> ();
		}

		rigidBody = GetComponent<Rigidbody2D> ();
	}

	abstract public void OnTap ();

	void OnClick ()
	{
		Activate ();
	}

	void OnPress ()
	{
		Activate ();
	}

	void Activate ()
	{
		if (DateTime.Now - lastTime > MinSpanBetweenTwoTouches) {
			lastTime = DateTime.Now;
			OnTap ();
		}
	}
}
