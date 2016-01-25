using UnityEngine;

public class SignTrigger : OscarEnterDetecter
{

	public GameObject shooter;

	protected override void OnOscarEnter ()
	{
		shooter.SetActive (true);
	}
}
