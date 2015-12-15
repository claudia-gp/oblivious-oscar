using UnityEngine;
using System.Collections;

public class ResetScene : RetryLevelInteraction
{
	public override void Send ()
	{
		Oscar.Instance.ResetToInitialPosition ();
		base.Send ();
	}
}
