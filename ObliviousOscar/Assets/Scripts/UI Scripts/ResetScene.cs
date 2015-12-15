using UnityEngine;
using System.Collections;

public class ResetScene : RetryLevelInteraction
{
	public override void Send ()
	{
		base.Send ();
		SavePointsManager.Instance.Reset ();
	}
}
