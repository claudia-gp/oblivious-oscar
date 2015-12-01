using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Behaviors;

public class Draggable : MonoBehaviour
{
	private Vector3 initialPosition;
	public bool fixedX = false;
	public bool fixedY = false;
	 

	void Start ()
	{
		initialPosition = transform.position;
		gameObject.AddComponent<TransformGesture> ();
		gameObject.AddComponent<Transformer> ();
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

}
