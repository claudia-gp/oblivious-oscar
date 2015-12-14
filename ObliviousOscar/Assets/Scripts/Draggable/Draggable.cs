using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
	public const string Tag = "Draggable";

	public bool fixedX;
	public bool fixedY;

	void Awake ()
	{
		tag = Tag;
	}
}
