using UnityEngine;
using System.Collections;

public class TappableBomb : Tappable {

	public override void OnClick ()
	{
		StartCoroutine (explosion());
	}

	public void OnDrag ()
	{
		OnClick ();
	}

	IEnumerator explosion(){
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (0.700f);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		StartCoroutine (explosion());
	}
}
