using UnityEngine;

public class StopsOscarOnPlatform : MonoBehaviour
{
	public GameObject endObject;
	public TappableSwitchElevator switch_;

	bool wasActivated;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (OscarEnterDetecter.IsOscar (coll.gameObject) && switch_.IsClicked && !wasActivated) {
			wasActivated = true;
			Oscar.Instance.SetIdle (true);
		}
		if (coll.gameObject == endObject) {
			Oscar.Instance.SetIdle (false);
		}
	}
}
