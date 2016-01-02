using UnityEngine;
using System.Collections;

public class OscarKeepMoving : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D oscar) {
		if (oscar.tag.Equals (Oscar.Tag)) {
			StartCoroutine (keepMoving());
		}
	}

	IEnumerator keepMoving (){
		yield return new WaitForSeconds (1);
		OscarController.Instance.ReverseDirection ();
	}
}
