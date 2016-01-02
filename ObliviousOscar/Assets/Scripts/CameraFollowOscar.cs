using UnityEngine;
using System.Collections;

public class CameraFollowOscar : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D oscar)
	{
		if (oscar.tag.Equals (Oscar.Tag)) {
			Camera.main.transform.SetParent (Oscar.Instance.transform);	
			OscarController.Instance.StopOscarAndSayHi ();
		}
	}
}
