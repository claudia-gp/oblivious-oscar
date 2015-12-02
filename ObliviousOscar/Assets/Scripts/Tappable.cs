using UnityEngine;
using System.Collections;
using TouchScript.Gestures;


public abstract class Tappable : MonoBehaviour
{
	
	protected Rigidbody2D rigidBody;
	protected Collider2D collider;

	public void Start ()
	{
		//automatically adds a Collider2D if the object doesn't have it
		collider = GetComponent<Collider2D> ();
		if (!(collider)) {
			gameObject.AddComponent<BoxCollider2D> ();
			collider = GetComponent<BoxCollider2D> ();
		}

		rigidBody = GetComponent<Rigidbody2D> ();

		TapGesture tapGesture = gameObject.AddComponent<TapGesture> ();
		tapGesture.UseSendMessage = true;
	}

	abstract public void OnTap ();
	
}
