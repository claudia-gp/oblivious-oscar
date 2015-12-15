using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D oscar)
	{
		if (oscar.tag.Equals (Oscar.Tag)) {
			Oscar.Instance.EndLevel ();
		}
	}
}
