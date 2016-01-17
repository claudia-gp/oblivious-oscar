using UnityEngine;
using System.Collections;

public class TappableBomb : Tappable
{

	public override void OnClick ()
	{
		StartCoroutine (explosion ());
	}

	public void OnDrag ()
	{
		OnClick ();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (OscarEnterDetecter.IsOscar (other.gameObject)) {
			StartCoroutine (explosion ());
		}
	}

	IEnumerator explosion ()
	{
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (0.700f);
		Destroy (this.gameObject);
	}
}
