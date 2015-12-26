using UnityEngine;

public class StopOscarOnTutorial : Tappable
{

	public override void OnClick ()
	{
		Oscar oscar = Oscar.Instance;
		oscar.IsAnimationEnabled = true;
		oscar.IsRunning = true;
		oscar.gameObject.GetComponent<SpriteRenderer> ().sprite = oscar.startSprite;
		Camera.main.transform.parent = oscar.transform;
	}

	public void OnDrag ()
	{
		OnClick ();
	}

	void OnTriggerEnter2D (Collider2D oscar)
	{
		if (oscar.tag.Equals (Oscar.Tag)) {
			OscarController.Instance.StopOscarAndSayHi ();
		}
	}
	
}
