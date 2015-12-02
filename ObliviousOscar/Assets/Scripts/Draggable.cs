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

	void Awake ()
	{
		initialPosition = transform.position;

		gesture = gameObject.AddComponent<TransformGesture> ();
		gameObject.AddComponent<Transformer> ();
	
		rb = GetComponent<Rigidbody2D> ();
		if (rb) {
			initialGravity = rb.gravityScale;
		}
	}

	void OnEnable ()
	{
		gesture.TransformStarted += TransformStartedHandler;
		gesture.TransformCompleted += TransformCompletedHandler;
	}
	
	void Update ()
	{
		Vector3 temp = transform.position;

		if (fixedY) {
			temp.y = initialPosition.y;
		}
		if (fixedX) {
			temp.x = initialPosition.x;
		}
		transform.position = temp;
	}
	
	private void TransformStartedHandler (object sender, System.EventArgs e)
	{
		rb.gravityScale = 0f;
	}
		
	private void TransformCompletedHandler (object sender, System.EventArgs e)
	{
		rb.gravityScale = initialGravity;
	}
	
}
