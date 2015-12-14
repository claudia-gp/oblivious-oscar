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
		initialPosition = transform.position;
		tag = Tag;
	}
}
