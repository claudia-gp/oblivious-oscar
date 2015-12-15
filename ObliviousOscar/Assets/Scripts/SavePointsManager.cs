using UnityEngine;
using System.Collections;

public class SavePointsManager : PersistentSingleton<SavePointsManager>
{
	//TODO: could be changed with array
	static readonly Hashtable positions = new Hashtable ();
			
	public Vector3 LatestPosition { 
		get {
			return (Vector3)positions [Application.loadedLevel];
		}
		set {
			positions [Application.loadedLevel] = value;
		}
	}


	void Start ()
	{
		LatestPosition = Oscar.Instance.transform.position;
	}
}
