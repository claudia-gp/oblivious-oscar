using UnityEngine;
using System.Collections;

public class TappableExplosive : Tappable
{
	KillingObject kobj;
	Animator animator;

	void Start ()
	{
		kobj = GetComponent<KillingObject> ();
		animator = GetComponent<Animator> ();
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
		animator.enabled = true;
		yield return new WaitForSeconds (0.700f);
		Destroy (gameObject);
	}
}
