using UnityEngine;
using System.Collections;

public class VerticalPlatformStop : MonoBehaviour {

	public GameObject plat;

	void OnCollisionEnter2D(Collider2D coll)
	{
		if (coll.gameObject == plat) {
			plat.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
		}
	}
}
