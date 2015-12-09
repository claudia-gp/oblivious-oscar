using UnityEngine;
using System.Collections;

public class SavePointsManager : PersistentSingleton<SavePointsManager>
{

	public Vector3 LatestPosition {	get; set; }

	protected new void Awake ()
	{
		base.Awake ();
		LatestPosition = Oscar.InitialPosition;
	}
}
