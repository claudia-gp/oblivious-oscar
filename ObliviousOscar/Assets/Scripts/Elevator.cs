using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D oscar)
	{
		if (oscar.tag.Equals (Oscar.Tag)) {
			Oscar.Instance.GetComponent<Rigidbody2D> ().isKinematic = true;

		}
	}
}
