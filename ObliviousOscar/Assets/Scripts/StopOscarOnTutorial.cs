using UnityEngine;
using System.Collections;

public class StopOscarOnTutorial : Tappable
{

	public override void OnClick ()
	{
		Oscar.Instance.gameObject.GetComponent<Animator> ().enabled = true;
		Oscar.Instance.gameObject.GetComponent<SpriteRenderer> ().sprite = Oscar.Instance.startSprite;
		Oscar.Instance.IsRunning = true;
		Camera.main.transform.parent = Oscar.Instance.transform;
	}

	public void OnPress ()
	{
		OnClick ();
	}

	public void OnDrag ()
	{
		OnClick ();
	}

	void OnTriggerEnter2D (Collider2D oscar)
	{
		if (oscar.tag.Equals (Oscar.Tag)) {
			Oscar.Instance.EndLevel ();
		}
	}
	
}
