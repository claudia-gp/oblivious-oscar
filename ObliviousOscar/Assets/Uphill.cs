using UnityEngine;

public class Uphill : MonoBehaviour
{
	float initialGravity, initialMass, initialAngularDrag;
	Rigidbody2D rb;

	void Start ()
	{
		rb = Oscar.Instance.RigidBody2D;
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (Oscar.IsOscar (coll.gameObject)) {
			initialGravity = rb.gravityScale;
			initialMass = rb.mass;
			initialAngularDrag = rb.angularDrag;

			rb.gravityScale = rb.mass = rb.angularDrag = 0f;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (Oscar.IsOscar (coll.gameObject)) {
			rb.gravityScale = initialGravity;
			rb.mass = initialMass;
			rb.angularDrag = initialAngularDrag;
		}
	}

}
