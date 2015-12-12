using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Behaviors;

public class Draggable : MonoBehaviour
{

	public bool fixedX;
	public bool fixedY;
	 
	Rigidbody2D rb;
	Vector3 initialPosition;
	TransformGesture gesture;
	float initialGravity = 1f;
	bool dragging;
	Transform initialParent;

	void Awake ()
	{
		initialPosition = transform.position;
		initialParent = transform.parent;

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

	void OnDisable ()
	{
		gesture.TransformStarted -= StartDrag;
		gesture.TransformCompleted -= EndDrag;
	}


	void Update ()
	{
		if (dragging) {
			if (fixedY) {
				transform.position = new Vector3 (transform.position.x, initialPosition.y);
			}
			if (fixedX) {
				transform.position = new Vector3 (initialPosition.x, transform.position.y);
			}
		}
	}

	void StartDrag (object sender, System.EventArgs e)
	{
		if (rb) {
			rb.gravityScale = 0f;
		}
		transform.SetParent (Camera.main.gameObject.transform);
		dragging = true;
	}

	void EndDrag (object sender, System.EventArgs e)
	{
		if (rb) {
			rb.gravityScale = initialGravity;
		}
		transform.SetParent (initialParent);
		dragging = false;
	}
	
}
