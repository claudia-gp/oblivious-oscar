using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour
{
	public const string Tag = "Draggable";

	public bool fixedX;
	public bool fixedY;

	public float limitX = float.PositiveInfinity;
	public float limitY = float.PositiveInfinity;

	public Vector3 initialPosition;

	public Rigidbody2D Rigidbody2D{ get; private set; }

	float initialGravity = 1f;

	void Awake ()
	{
		initialPosition = transform.position;
		tag = Tag;
		Rigidbody2D = GetComponent<Rigidbody2D> ();
		Rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.CompareTag (Oscar.Tag)) {
			initialGravity = Oscar.Instance.RigidBody2D.gravityScale;
			Oscar.Instance.RigidBody2D.gravityScale = 0f;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (coll.gameObject.CompareTag (Oscar.Tag)) {
			Oscar.Instance.RigidBody2D.gravityScale = initialGravity;
		}
	}
}
