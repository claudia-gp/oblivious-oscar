using UnityEngine;

public class VerticalPlatformStop : MonoBehaviour
{
	public Rigidbody2D platformRb;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject == platformRb.gameObject) {
			platformRb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}
}
