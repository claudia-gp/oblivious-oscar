using UnityEngine;
using System.Collections;

public class KillTheBox : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D box){
		Destroy (box.gameObject.transform.parent.gameObject);
	}
}
