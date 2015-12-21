using UnityEngine;
using System.Collections;

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

	void Awake ()
	{
		initialPosition = transform.position;
		tag = Tag;
		Rigidbody2D = GetComponent<Rigidbody2D> ();
		Rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
	}
}
