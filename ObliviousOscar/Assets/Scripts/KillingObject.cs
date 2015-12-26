using UnityEngine;

public class KillingObject : MonoBehaviour
{
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.Tag)) {
			OscarController.Instance.Kill ();
		}
	}

}
