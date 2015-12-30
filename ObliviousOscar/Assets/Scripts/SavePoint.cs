using UnityEngine;

public class SavePoint : MonoBehaviour
{
	void Awake ()
	{
		Collider2D coll = GetComponent<Collider2D> ();
		if (!coll) {
			coll = gameObject.AddComponent<BoxCollider2D> ();
		}
		coll.isTrigger = true;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.Tag)) {
			Oscar.Instance.UpdateLatestPosition ();
		}
	}
}
