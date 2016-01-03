using UnityEngine;

public class StopTheCamera : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (Oscar.IsOscar (coll.gameObject)) {
			Camera.main.transform.parent = null;			
		}
	}
}
