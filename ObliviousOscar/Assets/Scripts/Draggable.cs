using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Behaviors;

public class Draggable : MonoBehaviour
{

	public bool fixedX = false;
	public bool fixedY = false;
	 
	private Rigidbody2D rb;
	private Vector3 initialPosition;
	private TransformGesture gesture;
	private float initialGravity = 1f;
	private bool dragging = false;

	void Awake ()
	{
		initialPosition = transform.position;

		gesture = gameObject.AddComponent<TransformGesture> ();
		gesture.Type = TouchScript.Gestures.Base.TransformGestureBase.TransformType.Translation;

		gameObject.AddComponent<Transformer> ();
	
		rb = GetComponent<Rigidbody2D> ();
		if (rb) {
			initialGravity = rb.gravityScale;
		}
	}

	void OnEnable ()
	{
		gesture.TransformStarted += StartDrag;
		gesture.TransformCompleted += EndDrag;
	}

	private void OnDisable ()
	{
		gesture.TransformStarted -= StartDrag;
		gesture.TransformCompleted -= EndDrag;
	}


	void Update ()
	{
		if (dragging) {

			transform.position += Oscar.DeltaPosition;

			if (fixedY) {
				transform.position = new Vector3 (transform.position.x, initialPosition.y);
			}
			if (fixedX) {
				transform.position = new Vector3 (initialPosition.x, transform.position.y);
			}
		}
	}
	
	private void StartDrag (object sender, System.EventArgs e)
	{
		rb.gravityScale = 0f;
		dragging = true;
	}
		
	private void EndDrag (object sender, System.EventArgs e)
	{
		rb.gravityScale = initialGravity;
		dragging = false;
	}
	
}
