using UnityEngine;
using System.Collections;

public class TriggerBombsAppearing : MonoBehaviour {

	public GameObject bomb;
	SpriteRenderer sR;

	void Awake ()
	{
		sR = bomb.GetComponent<SpriteRenderer> ();
	}

	IEnumerator BombsAppear ()
	{
		yield return new WaitForSeconds (0.8f);
		sR.enabled = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag (Oscar.Tag)) {
			StartCoroutine (BombsAppear ());
		}

	}
}
