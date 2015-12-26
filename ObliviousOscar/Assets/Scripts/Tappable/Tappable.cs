using UnityEngine;


public abstract class Tappable : MonoBehaviour
{
	
	protected Rigidbody2D rigidBody;
	protected new Collider2D collider;

	protected void Start ()
	{
		//automatically adds a Collider2D if the object doesn't have it
		collider = GetComponent<Collider2D> ();
		if (!(collider)) {
			collider = gameObject.AddComponent<BoxCollider2D> ();
		}

		rigidBody = GetComponent<Rigidbody2D> ();
	}

	abstract public void OnClick ();

	public void OnPress ()
	{
		OnClick ();
	}
	
}
