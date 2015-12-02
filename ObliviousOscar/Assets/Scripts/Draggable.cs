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

	private void OnEnable ()
	{
		initialPosition = transform.position;
		
		gameObject.AddComponent<TransformGesture> ();
		gameObject.AddComponent<Transformer> ();
		
		rb = GetComponent<Rigidbody2D> ();
		
		TransformGesture gesture = GetComponent<TransformGesture> ();
		if (rb) {
			gesture.TransformStarted += transformStartedHandler;
			gesture.TransformCompleted += transformCompletedHandler;
		}
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
	
	private void transformStartedHandler (object sender, System.EventArgs e)
	{
		rb.isKinematic = true;

	}
		
	private void transformCompletedHandler (object sender, System.EventArgs e)
	{
		rb.isKinematic = false;
	}
	
}
