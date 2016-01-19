using UnityEngine;

public class StopOscarOnTutorial : Tappable
{

	public override void OnTap ()
	{
		Oscar oscar = Oscar.Instance;
		oscar.SetIdle (false);
		Camera.main.transform.parent = oscar.transform;
	}

	public void OnDrag ()
	{
		OnTap ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (OscarEnterDetecter.IsOscar (other.gameObject)) {
			Oscar.Instance.SetIdle (true);
		}
	}
	
}
