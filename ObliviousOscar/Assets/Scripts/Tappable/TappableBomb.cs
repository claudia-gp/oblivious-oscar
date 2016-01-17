using UnityEngine;
using System.Collections;

public class TappableBomb : Tappable
{
	KillingObject kobj;

	void Start ()
	{
		kobj = GetComponent<KillingObject> ();
	}

	public override void OnTap ()
	{
		StartCoroutine (Explosion ());
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (OscarEnterDetecter.IsOscar (other.gameObject)) {
			StartCoroutine (Explosion ());
		}
	}

	IEnumerator Explosion ()
	{
		Destroy (kobj);
		Destroy (collider);
		SoundManager.Instance.Play (SoundManager.Instance.Explosion);
		gameObject.GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (0.700f);
		Destroy (gameObject);
	}
}
