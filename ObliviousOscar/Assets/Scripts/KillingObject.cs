using UnityEngine;
using System.Collections;

public class KillingObject : MonoBehaviour
{

	void Start ()
	{
		if (!gameObject.GetComponent<BoxCollider2D> ()) {
			gameObject.AddComponent<BoxCollider2D> ();
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.TAG)) {
			Camera.main.transform.parent = null;
			Destroy (other.gameObject);
		}
	}

}
