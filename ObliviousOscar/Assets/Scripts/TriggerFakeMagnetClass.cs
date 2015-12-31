using UnityEngine;

public class TriggerFakeMagnetClass : MonoBehaviour
{
	public GameObject magnet;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.Tag)) {
			Destroy (magnet.GetComponent<TappableMagnet> ());
		}
	}
}
