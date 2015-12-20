using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
	public const string Tag = "Draggable";

	public bool fixedX;
	public bool fixedY;

	public float limitX = float.PositiveInfinity;
	public float limitY = float.PositiveInfinity;

	public Vector3 initialPosition;

	void Awake ()
	{

#if UNITY_EDITOR
		if (GetComponent<Rigidbody2D> () == null) {
			Debug.LogWarning ("The draggable objects must have a Rigidbody2D");
		}
#endif

		initialPosition = transform.position;
		tag = Tag;
	}
}
