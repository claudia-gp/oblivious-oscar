using UnityEngine;

public class KillingObject : MonoBehaviour
{
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		KillAction (collider.gameObject);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		KillAction (collision.gameObject);
	}

	void KillAction (GameObject other)
	{
		if (Oscar.IsOscar (other)) {
			OscarController.Instance.Kill ();
		}
	}

}
