using UnityEngine;

public class KeepWalking : MonoBehaviour
{
	public Rigidbody2D elevatorRb;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject == elevatorRb.gameObject) {
			Oscar.Instance.SetIdle (false);
		}
	}
}
