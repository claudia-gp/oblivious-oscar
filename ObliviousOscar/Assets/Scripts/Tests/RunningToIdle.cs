using UnityEngine;
using System.Collections;

public class RunningToIdle : OscarEnterDetecter
{
	protected override void OnOscarEnter ()
	{
		Oscar.Instance.SetIdle (true);
		GetComponent<SpriteRenderer> ().enabled = false;
		StartCoroutine (WaitToRun ());
	}

	IEnumerator WaitToRun ()
	{
		yield return new WaitForSeconds (3.55f);
		Oscar.Instance.SetIdle (false);
		yield return new WaitForSeconds (1f);
		LevelManager.ReloadCurrent ();

	}

}
