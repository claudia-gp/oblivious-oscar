using UnityEngine;
using System.Collections;

public class TappableBomb : Tappable
{

	public override void OnClick ()
	{
		StartCoroutine (Explosion ());
	}

	public void OnDrag ()
	{
		OnClick ();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (OscarEnterDetecter.IsOscar (other.gameObject)) {
			StartCoroutine (Explosion ());
		}
	}

	IEnumerator Explosion ()
	{
		SoundManager.Instance.Play (SoundManager.Instance.Explosion);
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (0.700f);
		Destroy (this.gameObject);
	}
}
