using UnityEngine;
using System.Collections;

public class KillingObject : MonoBehaviour
{

	void Start ()
	{
		if (!gameObject.GetComponent<Collider2D> ()) {
			gameObject.AddComponent<BoxCollider2D> ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.Tag)) {
			Oscar.Instance.Kill ();
		}
	}

}
