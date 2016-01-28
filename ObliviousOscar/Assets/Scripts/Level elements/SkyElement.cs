using UnityEngine;

public class SkyElement : MonoBehaviour
{
	public float probability = 1f;

	void Start ()
	{
		if (Random.value < probability) {
			transform.position = transform.position + new Vector3 (Random.value * 100, 0f);
		} else {
			Destroy (gameObject);
		}
	}

}
