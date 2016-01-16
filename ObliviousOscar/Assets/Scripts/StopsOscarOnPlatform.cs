using UnityEngine;

public class StopsOscarOnPlatform : MonoBehaviour
{
	public GameObject endObject;
	public TappableSwitchElevator switch_;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (OscarEnterDetecter.IsOscar (coll.gameObject) && switch_.IsClicked) {
			Oscar.Instance.IsRunning = false;
		}
		if (coll.gameObject == endObject) {
			Oscar.Instance.IsRunning = true;
		}
	}
}
