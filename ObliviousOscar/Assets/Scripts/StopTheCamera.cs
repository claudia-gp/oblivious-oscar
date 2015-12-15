using UnityEngine;
using System.Collections;

public class StopTheCamera : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D oscar)
	{
		if (oscar.tag.Equals (Oscar.Tag)) {
			Camera.main.transform.parent = null;			
		}
	}
}
