using UnityEngine;
using System.Collections;

public class TriggerFallingBoxes : MonoBehaviour
{
	const float GravityScale = 0.3f;
	public GameObject box;
	public float gravityIndex = 4f;
	Rigidbody2D rb;

	void Awake ()
	{
		rb = box.GetComponent<Rigidbody2D> ();
	}

	IEnumerator RevertGravity ()
	{
		yield return new WaitForSeconds (0.5f);
		rb.gravityScale = GravityScale;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.Tag)) {
			rb.isKinematic = false;
			rb.gravityScale = gravityIndex;
			StartCoroutine (RevertGravity ());
		}

	}
}


