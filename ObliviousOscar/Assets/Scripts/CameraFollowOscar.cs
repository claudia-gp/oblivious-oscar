using UnityEngine;

public class CameraFollowOscar : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (Oscar.IsOscar (coll.gameObject)) {
			Camera.main.transform.SetParent (Oscar.Instance.transform);	
			OscarController.Instance.StopOscarAndSayHi ();
		}
	}
}
