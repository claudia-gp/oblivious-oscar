using UnityEngine;
using System.Collections;

public class SavePointsManager : PersistentSingleton<SavePointsManager>
{
	//TODO: could be changed with array
	static readonly Hashtable positions = new Hashtable ();
	static readonly Hashtable initialPositions = new Hashtable ();
			
	public Vector3 LatestPosition { 
		get {
			if (positions [Application.loadedLevel] != null)
				return (Vector3)positions [Application.loadedLevel];
			else
				return InitialPosition;
		}
		set {
			positions [Application.loadedLevel] = value;
		}
	}

	Vector3 InitialPosition {
		get {
			if (initialPositions [Application.loadedLevel] != null)
				return (Vector3)initialPositions [Application.loadedLevel];
			else
				return Oscar.Instance.transform.position;
		}
		set {
			initialPositions [Application.loadedLevel] = value;
		}
	}

	public void OnEnable ()
	{
		LatestPosition = Oscar.Instance.transform.position;
		InitialPosition = Oscar.Instance.transform.position;
	}

	public void Reset ()
	{
		LatestPosition = InitialPosition;
	}
}
