using UnityEngine;
using System.Collections;

public class SavePointsManager : PersistentSingleton<SavePointsManager>
{

	public Vector3 LatestPosition {	get; set; }

	void Start ()
	{
		LatestPosition = Oscar.Instance.transform.position;
	}
}
