using UnityEngine;
using System.Collections;
using TouchScript.Gestures;


public abstract class Tappable : MonoBehaviour
{
	
	protected Rigidbody2D rigidBody;
	protected BoxCollider2D boxCollider;

	public void Start ()
	{
		//automatically adds a BoxCollider2D if the object doesn't have it
		boxCollider = GetComponent<BoxCollider2D> ();
		if (!(boxCollider)) {
			gameObject.AddComponent<BoxCollider2D> ();
			boxCollider = GetComponent<BoxCollider2D> ();
		}

		rigidBody = GetComponent<Rigidbody2D> ();

		TapGesture tapGesture = gameObject.AddComponent<TapGesture> ();
		tapGesture.UseSendMessage = true;
	}

	abstract public void OnTap ();
	
}
