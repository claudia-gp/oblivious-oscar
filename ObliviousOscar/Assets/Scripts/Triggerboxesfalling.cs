using UnityEngine;
using System.Collections;

public class Triggerboxesfalling : MonoBehaviour {

	public GameObject box1;
	public GameObject box2;
	public GameObject box3;
	public float gravityIndex;

	void Start () {
	}

	void Update () {
	}

	IEnumerator revertGravity(){
		yield return new WaitForSeconds (0.5f);
		box1.GetComponent<Rigidbody2D> ().gravityScale = 0.3f;
		box2.GetComponent<Rigidbody2D> ().gravityScale = 0.3f;
		box3.GetComponent<Rigidbody2D> ().gravityScale = 0.3f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Oscar.Tag)) {
			box1.GetComponent<Rigidbody2D> ().gravityScale = gravityIndex;
			box2.GetComponent<Rigidbody2D> ().gravityScale = gravityIndex;
			box3.GetComponent<Rigidbody2D> ().gravityScale = gravityIndex;
			StartCoroutine (revertGravity ());
		}

	}
}
